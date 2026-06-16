-- Tắt kiểm tra khóa ngoại tạm thời để tránh lỗi xung đột khi chèn dữ liệu
SET FOREIGN_KEY_CHECKS = 0;

-- Xóa dữ liệu cũ trong các bảng PascalCase (nếu có)
TRUNCATE TABLE `CartItems`;
TRUNCATE TABLE `OrderDetails`;
TRUNCATE TABLE `Payments`;
TRUNCATE TABLE `Reviews`;
TRUNCATE TABLE `Cart`;
TRUNCATE TABLE `Orders`;
TRUNCATE TABLE `Products`;
TRUNCATE TABLE `Users`;
TRUNCATE TABLE `Categories`;
TRUNCATE TABLE `Roles`;
TRUNCATE TABLE `PaymentMethods`;

-- 1. Chèn dữ liệu vào bảng Roles
INSERT INTO `Roles` (`RoleId`, `RoleName`) VALUES 
(1,'Admin'),
(2,'Customer'),
(5,'Guest'),
(4,'Manager'),
(3,'Staff');

-- 2. Chèn dữ liệu vào bảng Categories
INSERT INTO `Categories` (`CategoryId`, `CategoryName`, `Description`) VALUES 
(1,'Edible Cup','Edible waffle cups'),
(2,'Combo','Combo products'),
(3,'Topping','Extra toppings'),
(4,'Gift Set','Gift collection'),
(5,'Limited Edition','Special seasonal products');

-- 3. Chèn dữ liệu vào bảng Users
INSERT INTO `Users` (`UserId`, `FullName`, `Email`, `PasswordHash`, `Phone`, `Address`, `RoleId`, `CreatedAt`) VALUES 
(1,'Nguyen Van A','a@gmail.com','123456','0901111111','Ha Noi',1,'2026-06-14 22:41:47'),
(2,'Tran Thi B','b@gmail.com','123456','0902222222','Hai Phong',2,'2026-06-14 22:41:47'),
(3,'Le Van C','c@gmail.com','123456','0903333333','Da Nang',2,'2026-06-14 22:41:47'),
(4,'Pham Thi D','d@gmail.com','123456','0904444444','TP HCM',3,'2026-06-14 22:41:47'),
(5,'Hoang Van E','e@gmail.com','123456','0905555555','Can Tho',4,'2026-06-14 22:41:47'),
(6,'Pham Minh Tuan','tuan@gmail.com','123456','0911111111','Ha Noi',2,'2026-06-14 22:41:47'),
(7,'Nguyen Thu Ha','thuha@gmail.com','123456','0922222222','Hai Duong',2,'2026-06-14 22:41:47'),
(8,'Tran Quoc Bao','quocbao@gmail.com','123456','0933333333','Nam Dinh',2,'2026-06-14 22:41:47'),
(9,'Le Ngoc Anh','ngocanh@gmail.com','123456','0944444444','Nghe An',2,'2026-06-14 22:41:47'),
(10,'Do Thanh Huyen','thanhhuyen@gmail.com','123456','0955555555','Hue',2,'2026-06-14 22:41:47');

-- 4. Chèn dữ liệu vào bảng Products
INSERT INTO `Products` (`ProductId`, `ProductName`, `Description`, `Price`, `Stock`, `Flavor`, `Size`, `CategoryId`, `ImageUrl`, `CreatedAt`) VALUES 
(1,'Cốc Nguyên Bản','Cốc làm từ ngũ cốc',21000.00,100,'Nguyên bản','Medium',1,'vanilla.jpg','2026-06-14 22:41:47'),
(2,'Cốc Than Tre','Cốc làm từ ngũ cốc và bột than tre',23000.00,120,'Than tre','Large',1,'chocolate.jpg','2026-06-14 22:41:47'),
(3,'Combo Nguyên Bản','Cốc làm từ ngũ cốc',60000.00,80,'Nguyên bản','Medium',2,'combo-nguyen-ban.jpg','2026-06-14 22:41:47'),
(4,'Combo Than Tre','Cốc làm từ ngũ cốc và bột than tre',6000.00,90,'Than tre','Medium',2,'combo-than-tre.jpg','2026-06-14 22:41:47'),
(5,'Combo Family Pack','Combo 5 edible cups',110000.00,50,'Mixed','Large',2,'combo.jpg','2026-06-14 22:41:47');

-- 5. Chèn dữ liệu vào bảng Cart
INSERT INTO `Cart` (`CartId`, `UserId`, `CreatedAt`) VALUES 
(1,1,'2026-06-14 22:41:47'),
(2,2,'2026-06-14 22:41:47'),
(3,3,'2026-06-14 22:41:47'),
(4,4,'2026-06-14 22:41:47'),
(5,5,'2026-06-14 22:41:47');

-- 6. Chèn dữ liệu vào bảng CartItems
INSERT INTO `CartItems` (`CartItemId`, `CartId`, `ProductId`, `Quantity`) VALUES 
(1,1,1,2),
(2,2,2,1),
(3,3,3,4),
(4,4,4,2),
(5,5,5,1);

-- 7. Chèn dữ liệu vào bảng Orders
INSERT INTO `Orders` (`OrderId`, `UserId`, `OrderDate`, `TotalAmount`, `Status`, `ShippingAddress`) VALUES 
(1,1,'2026-06-14 22:41:47',90000.00,'Pending','Ha Noi'),
(2,2,'2026-06-14 22:41:47',50000.00,'Completed','Hai Phong'),
(3,3,'2026-06-14 22:41:47',220000.00,'Shipping','Da Nang'),
(4,4,'2026-06-14 22:41:47',104000.00,'Cancelled','TP HCM'),
(5,5,'2026-06-14 22:41:47',199000.00,'Completed','Can Tho');

-- 8. Chèn dữ liệu vào bảng OrderDetails
INSERT INTO `OrderDetails` (`OrderDetailId`, `OrderId`, `ProductId`, `Quantity`, `UnitPrice`) VALUES 
(1,1,1,2,45000.00),
(2,2,2,1,50000.00),
(3,3,3,4,55000.00),
(4,4,4,2,52000.00),
(5,5,5,1,199000.00);

-- 9. Chèn dữ liệu vào bảng PaymentMethods
INSERT INTO `PaymentMethods` (`PaymentMethodId`, `MethodName`, `Description`, `IsActive`) VALUES 
(1,'COD','Cash On Delivery',1),
(2,'VNPay','VNPay Gateway',1),
(3,'Momo','Momo E-Wallet',1),
(4,'Banking','Internet Banking',1),
(5,'PayPal','PayPal Payment',1);

-- 10. Chèn dữ liệu vào bảng Payments
INSERT INTO `Payments` (`PaymentId`, `OrderId`, `PaymentMethodId`, `PaymentStatus`, `TransactionCode`, `PaidAt`) VALUES 
(1,1,1,'Pending','COD001','2026-06-14 22:41:47'),
(2,2,2,'Paid','VNP002','2026-06-14 22:41:47'),
(3,3,3,'Paid','MOMO003','2026-06-14 22:41:47'),
(4,4,1,'Cancelled','COD004','2026-06-14 22:41:47'),
(5,5,4,'Paid','BANK005','2026-06-14 22:41:47');

-- 11. Chèn dữ liệu vào bảng Reviews
INSERT INTO `Reviews` (`ReviewId`, `UserId`, `ProductId`, `Rating`, `Comment`, `CreatedAt`) VALUES 
(1,1,1,5,'Very delicious and crispy','2026-06-14 22:41:47'),
(2,2,2,4,'Chocolate flavor is great','2026-06-14 22:41:47'),
(3,3,3,5,'Perfect with ice cream','2026-06-14 22:41:47'),
(4,4,4,3,'Good but a bit sweet','2026-06-14 22:41:47'),
(5,5,5,5,'Excellent combo pack','2026-06-14 22:41:47');

-- Bật lại kiểm tra khóa ngoại
SET FOREIGN_KEY_CHECKS = 1;
