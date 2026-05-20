# Sweet Shell Cup - Ice Cream Shop Prototype

## Tổng quan
Đây là một prototype hoàn chỉnh của trang web cửa hàng kem Sweet Shell Cup, được xây dựng bằng React, React Router và Tailwind CSS.

## Cấu trúc ứng dụng

### Các trang chính:

1. **Home** (`/`)
   - Trang chủ với banner chính
   - Giới thiệu về Sweet Shell Cup
   - Hình ảnh sản phẩm nổi bật

2. **Our Story** (`/our-story`)
   - Câu chuyện thương hiệu
   - Tầm nhìn, sứ mệnh
   - Giá trị cốt lõi

3. **Shop** (`/shop`)
   - Danh sách sản phẩm
   - Lưới hiển thị các loại kem
   - Click vào sản phẩm để xem chi tiết

4. **Cart** (`/cart`)
   - Giỏ hàng của khách
   - Bảng thông tin sản phẩm
   - Tính tổng giá và thanh toán

5. **Feedback** (`/feedback`)
   - Đánh giá từ khách hàng
   - Hình ảnh minh họa
   - Testimonials

6. **Product Detail** (`/detail/:id`)
   - Chi tiết sản phẩm
   - Mô tả, thành phần
   - Đánh giá sao
   - Nút Back để quay lại Shop

## Điều hướng

### Menu Navigation:
Tất cả các trang đều có menu điều hướng ở header với các mục:
- Home
- Our Story
- Shop
- Cart
- Feedback
- Contact

Click vào bất kỳ mục nào trong menu để chuyển trang.

### Các hành động khác:
- **Từ Shop → Detail**: Click vào hình ảnh sản phẩm hoặc biểu tượng giỏ hàng
- **Từ Detail → Shop**: Click nút "Back"

## Công nghệ sử dụng

- **React 18.3.1**
- **React Router 7.13.0** - Quản lý routing
- **Tailwind CSS 4.1.12** - Styling
- **TypeScript** - Type safety
- **Vite** - Build tool

## Cách chạy

Ứng dụng đã được cấu hình tự động. Vite dev server đang chạy, bạn có thể xem prototype trong preview pane.

## Cấu trúc code

```
src/
├── app/
│   ├── App.tsx              # Entry point với RouterProvider
│   ├── routes.tsx           # Cấu hình routing
│   └── pages/               # Các trang wrapper
│       ├── HomePage.tsx
│       ├── OurStoryPage.tsx
│       ├── ShopPage.tsx
│       ├── CartPage.tsx
│       ├── FeedbackPage.tsx
│       └── DetailPage.tsx
├── imports/                  # Các component từ Figma
│   ├── CuisineIceCream.../
│   ├── OurStory/
│   ├── Product/
│   ├── Cart/
│   ├── Feedback/
│   └── Detail/
└── styles/                   # CSS files
```

## Tính năng

✅ Navigation đầy đủ giữa các trang
✅ Responsive design
✅ Interactive menu
✅ Product browsing
✅ Shopping cart view
✅ Customer feedback display
✅ Product detail view
✅ Back navigation

## Ghi chú

- Tất cả các design đều được import trực tiếp từ Figma
- Navigation được xử lý bằng React Router
- Click handlers được thêm vào để cho phép điều hướng
- Prototype này giữ nguyên 100% design từ Figma
