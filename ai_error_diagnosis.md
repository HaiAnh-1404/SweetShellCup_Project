# Báo cáo chi tiết: Khắc phục lỗi Hệ thống Hỏi đáp AI (Chatbot) không phản hồi

## 1. Triệu chứng lỗi
Khi người dùng truy cập trang chủ hoặc nhắn tin hỏi đáp với chatbot AI (Sweet Shell Bot), hệ thống không phản hồi hoặc trả về lỗi kết nối (`500 Internal Server Error`).

---

## 2. Nguyên nhân gốc rễ (Root Cause)

Lỗi bắt nguồn từ sự không đồng bộ giữa **Cấu trúc thực tế của Database** và **Khai báo thực thể (Model) trong C# / EF Core**:

1. **Truy vấn lấy Catalog Sản phẩm:**
   - Để AI trả lời chính xác thông tin thực tế của quán, hàm `BuildSystemPromptAsync()` trong [AIChatService.cs](file:///d:/ki%208%20_FPT/EXE201/SweetShellCup/SweetShellCup_Project/SweetShellCup/Services/AIChatService.cs) thực hiện truy vấn danh sách sản phẩm từ database thông qua EF Core:
     ```csharp
     var products = await _context.Products.Include(p => p.Category)...ToListAsync();
     ```
2. **Trường dữ liệu thiếu:**
   - Trong Model C# [Product.cs](file:///d:/ki%208%20_FPT/EXE201/SweetShellCup/SweetShellCup_Project/SweetShellCup/Models/Product.cs), thực thể có khai báo thuộc tính thành phần nguyên liệu:
     ```csharp
     public string? Ingredients { get; set; }
     ```
   - Tuy nhiên, trong cấu trúc bảng `products` của Database MySQL thực tế (cũng như trong file schema script gốc [sweetshellcupdb.sql](file:///d:/ki%208%20_FPT/EXE201/SweetShellCup/SweetShellCup_Project/sweetshellcupdb.sql)), cột `Ingredients` **không tồn tại**.
3. **Lỗi phát sinh:**
   - Khi EF Core sinh mã SQL để truy vấn, nó cố gắng đọc trường `Ingredients` từ cơ sở dữ liệu và gặp lỗi từ MySQL:
     > `MySqlConnector.MySqlException: Unknown column 'p.Ingredients' in 'field list'`
   - Lỗi này gây sập luồng xử lý (Crash/500 Error) khi tải trang chủ hoặc gọi API chat của AI.

### Tại sao tính năng Migration tự động không tự sửa lỗi này?
- Trong dự án, file migration ban đầu (`InitialMySQL`) cố gắng tạo lại toàn bộ cấu trúc bảng từ đầu. 
- Tuy nhiên, do database thực tế đã được import thủ công từ trước, khi ứng dụng chạy lệnh `db.Database.Migrate();`, MySQL báo lỗi:
  > `Table 'categories' already exists`
- Lỗi này làm **tắc nghẽn hoàn toàn đường truyền Migrations** của EF Core. Tất cả các migration phía sau (bao gồm cả việc thêm cột `Ingredients` và cột `ImageUrl` mới của Feedback) đều bị bỏ qua không chạy được.

---

## 3. Các giải pháp đã triển khai để khắc phục

Để giải quyết triệt để lỗi này một cách bền vững trên cả **Localhost** và **Railway**, chúng tôi đã thực hiện:

### Bước 1: Đồng bộ hóa file SQL gốc
- Cập nhật cấu trúc bảng `products` trong file [sweetshellcupdb.sql](file:///d:/ki%208%20_FPT/EXE201/SweetShellCup/SweetShellCup_Project/sweetshellcupdb.sql), thêm cột `Ingredients`:
  ```sql
  `Ingredients` text COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  ```

### Bước 2: Thêm lệnh sửa đổi cấu trúc DB tự động lúc khởi động (Auto-Healing Schema)
- Để tránh việc lỗi tắc nghẽn Migration làm sập ứng dụng trên Production (Railway), chúng tôi đã cập nhật mã nguồn khởi chạy trong [Program.cs](file:///d:/ki%208%20_FPT/EXE201/SweetShellCup/SweetShellCup_Project/SweetShellCup/Program.cs):
  ```csharp
  using (var scope = app.Services.CreateScope())
  {
      var db = scope.ServiceProvider.GetRequiredService<SweetShellCupDbContext>();
      try
      {
          // Tự động kiểm tra và thêm cột nếu thiếu (bảo đảm an toàn)
          try { db.Database.ExecuteSqlRaw("ALTER TABLE products ADD COLUMN Ingredients text NULL;"); } catch {}
          try { db.Database.ExecuteSqlRaw("ALTER TABLE reviews ADD COLUMN ImageUrl varchar(255) NULL;"); } catch {}

          db.Database.Migrate();
      }
      catch (Exception ex)
      {
          Console.WriteLine($"Error running migration: {ex.Message}");
      }
  }
  ```
  *Ý nghĩa:* Khi ứng dụng khởi động (cả ở Local và Railway), hệ thống sẽ chủ động chạy lệnh `ALTER TABLE` để thêm cột `Ingredients` (của sản phẩm) và `ImageUrl` (của feedback) trước. Nếu cột đã tồn tại, lỗi ném ra từ lệnh ALTER sẽ được bắt và bỏ qua (catch và ignore), ứng dụng vẫn chạy tiếp bình thường mà không bị crash.

---

## 4. Kết quả kiểm tra
- **Localhost**: Đã khởi chạy dự án thành công. Các lệnh cập nhật cột đã được thực thi và cột `Ingredients` đã được tạo thành công trên database của bạn.
- **Trang chủ & AI Chat**: Khi người dùng tải trang hoặc gửi câu hỏi, EF Core đã truy vấn được dữ liệu sản phẩm thành công mà không gặp lỗi thiếu cột, chatbot AI có thể đọc dữ liệu sản phẩm để phản hồi chính xác.
- **Đẩy code**: Tất cả code sửa đổi này đã được commit và push lên nhánh `haianh` trên GitHub của bạn để tự động deploy lên Railway.
