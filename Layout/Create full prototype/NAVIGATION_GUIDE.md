# 🧭 Navigation Guide - Sweet Shell Cup Prototype

## Trang chủ (Home) - `/`

**Nội dung:**
- Banner chính với slogan "Ẩm thực toàn cầu gặp gỡ Sweet Shell Cup"
- Câu chuyện thương hiệu
- Hình ảnh sản phẩm
- Footer với thông tin liên hệ

**Điều hướng từ trang này:**
- Click "Our Story" → Đến trang câu chuyện
- Click "Shop" → Đến trang sản phẩm
- Click "Cart" → Đến giỏ hàng
- Click "Feedback" → Đến trang đánh giá

---

## Our Story - `/our-story`

**Nội dung:**
- Câu chuyện Sweet Shell Cup
- Tầm nhìn
- Sứ mệnh
- Giá trị cốt lõi
- Hình ảnh thương hiệu

**Điều hướng từ trang này:**
- Click menu để đi đến các trang khác

---

## Shop (Sản phẩm) - `/shop`

**Nội dung:**
- Lưới hiển thị các sản phẩm kem
- Thông tin sản phẩm: tên, giá, đánh giá
- Hình ảnh sản phẩm chất lượng cao

**Điều hướng từ trang này:**
- Click vào **hình ảnh sản phẩm** → Xem chi tiết
- Click vào **icon giỏ hàng** trên sản phẩm → Xem chi tiết
- Click menu để đi đến các trang khác

---

## Product Detail - `/detail/1`

**Nội dung:**
- Hình ảnh sản phẩm lớn
- Tên: "Cốc bột nguyên cám"
- Giá: 13.00$
- Đánh giá: 5 sao (120 đánh giá)
- Mô tả ngắn
- Thành phần: bột nguyên cám, trứng, đường, bơ

**Điều hướng từ trang này:**
- Click nút **"Back"** → Quay lại trang Shop

---

## Cart (Giỏ hàng) - `/cart`

**Nội dung:**
- Bảng thông tin sản phẩm
- Các cột: Thông tin sản phẩm, Đơn giá, Số lượng, Chiết khấu, Tổng giá
- Nút thanh toán
- Sản phẩm mẫu hiển thị

**Điều hướng từ trang này:**
- Click menu để đi đến các trang khác

---

## Feedback (Đánh giá) - `/feedback`

**Nội dung:**
- Banner Sweet Shell Cup
- 3 testimonials từ khách hàng:
  1. Nguyễn Thế Tài
  2. Dũng
  3. Tùng Sơn
- Hình ảnh minh họa
- Nút "Customer Reviews"

**Điều hướng từ trang này:**
- Click menu để đi đến các trang khác

---

## 🎯 Quick Navigation Paths

### Path 1: Xem và mua sản phẩm
```
Home → Shop → Product Detail → Back to Shop → Cart
```

### Path 2: Tìm hiểu thương hiệu
```
Home → Our Story → Feedback
```

### Path 3: Hoàn tất mua hàng
```
Shop → Product Detail → Back → Shop → Cart
```

---

## 📍 Menu Navigation (Có ở tất cả các trang)

Header menu luôn hiển thị các mục sau:
- **Home** - Về trang chủ
- **Our Story** - Câu chuyện thương hiệu
- **Shop** - Danh sách sản phẩm
- **Cart** - Giỏ hàng
- **Feedback** - Đánh giá khách hàng
- **Contact** - Liên hệ

---

## 🔍 Các tính năng tương tác

1. ✅ Click vào bất kỳ mục menu nào để chuyển trang
2. ✅ Click vào sản phẩm trong Shop để xem chi tiết
3. ✅ Click "Back" trong trang Detail để quay lại
4. ✅ Tất cả navigation hoạt động smooth không reload trang
5. ✅ URL thay đổi khi chuyển trang

---

## 💡 Tips

- **React Router** được sử dụng cho client-side navigation
- Không có page reload khi chuyển trang
- Browser back/forward buttons hoạt động bình thường
- Có thể bookmark bất kỳ trang nào

---

**Prototype đầy đủ và sẵn sàng để demo!** 🎉
