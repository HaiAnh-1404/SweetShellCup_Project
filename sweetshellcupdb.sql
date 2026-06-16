-- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
--
-- Host: localhost    Database: sweetshellcupdb
-- ------------------------------------------------------
-- Server version	8.0.46

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cart`
--

DROP TABLE IF EXISTS `cart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cart` (
  `CartId` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`CartId`),
  KEY `FK_Cart_Users` (`UserId`),
  CONSTRAINT `FK_Cart_Users` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cart`
--

LOCK TABLES `cart` WRITE;
/*!40000 ALTER TABLE `cart` DISABLE KEYS */;
INSERT INTO `cart` VALUES (1,1,'2026-06-14 22:41:47'),(2,2,'2026-06-14 22:41:47'),(3,3,'2026-06-14 22:41:47'),(4,4,'2026-06-14 22:41:47'),(5,5,'2026-06-14 22:41:47');
/*!40000 ALTER TABLE `cart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cartitems`
--

DROP TABLE IF EXISTS `cartitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cartitems` (
  `CartItemId` int NOT NULL AUTO_INCREMENT,
  `CartId` int NOT NULL,
  `ProductId` int NOT NULL,
  `Quantity` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`CartItemId`),
  KEY `FK_CartItems_Products` (`ProductId`),
  KEY `IX_CartItems_CartId` (`CartId`),
  CONSTRAINT `FK_CartItems_Cart` FOREIGN KEY (`CartId`) REFERENCES `cart` (`CartId`),
  CONSTRAINT `FK_CartItems_Products` FOREIGN KEY (`ProductId`) REFERENCES `products` (`ProductId`),
  CONSTRAINT `CK_CartItems_Quantity` CHECK ((`Quantity` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cartitems`
--

LOCK TABLES `cartitems` WRITE;
/*!40000 ALTER TABLE `cartitems` DISABLE KEYS */;
INSERT INTO `cartitems` VALUES (1,1,1,2),(2,2,2,1),(3,3,3,4),(4,4,4,2),(5,5,5,1);
/*!40000 ALTER TABLE `cartitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `CategoryId` int NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Description` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`CategoryId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Edible Cup','Edible waffle cups'),(2,'Combo','Combo products'),(3,'Topping','Extra toppings'),(4,'Gift Set','Gift collection'),(5,'Limited Edition','Special seasonal products');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderdetails`
--

DROP TABLE IF EXISTS `orderdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderdetails` (
  `OrderDetailId` int NOT NULL AUTO_INCREMENT,
  `OrderId` int NOT NULL,
  `ProductId` int NOT NULL,
  `Quantity` int NOT NULL,
  `UnitPrice` decimal(10,2) NOT NULL,
  PRIMARY KEY (`OrderDetailId`),
  KEY `FK_OrderDetails_Products` (`ProductId`),
  KEY `IX_OrderDetails_OrderId` (`OrderId`),
  CONSTRAINT `FK_OrderDetails_Orders` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`OrderId`),
  CONSTRAINT `FK_OrderDetails_Products` FOREIGN KEY (`ProductId`) REFERENCES `products` (`ProductId`),
  CONSTRAINT `CK_OrderDetails_Quantity` CHECK ((`Quantity` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderdetails`
--

LOCK TABLES `orderdetails` WRITE;
/*!40000 ALTER TABLE `orderdetails` DISABLE KEYS */;
INSERT INTO `orderdetails` VALUES (1,1,1,2,45000.00),(2,2,2,1,50000.00),(3,3,3,4,55000.00),(4,4,4,2,52000.00),(5,5,5,1,199000.00);
/*!40000 ALTER TABLE `orderdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `OrderId` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `OrderDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `TotalAmount` decimal(10,2) NOT NULL,
  `Status` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT 'Pending',
  `ShippingAddress` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`OrderId`),
  KEY `IX_Orders_UserId` (`UserId`),
  CONSTRAINT `FK_Orders_Users` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`),
  CONSTRAINT `CK_Orders_Total` CHECK ((`TotalAmount` >= 0))
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,1,'2026-06-14 22:41:47',90000.00,'Pending','Ha Noi'),(2,2,'2026-06-14 22:41:47',50000.00,'Completed','Hai Phong'),(3,3,'2026-06-14 22:41:47',220000.00,'Shipping','Da Nang'),(4,4,'2026-06-14 22:41:47',104000.00,'Cancelled','TP HCM'),(5,5,'2026-06-14 22:41:47',199000.00,'Completed','Can Tho');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paymentmethods`
--

DROP TABLE IF EXISTS `paymentmethods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paymentmethods` (
  `PaymentMethodId` int NOT NULL AUTO_INCREMENT,
  `MethodName` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Description` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`PaymentMethodId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paymentmethods`
--

LOCK TABLES `paymentmethods` WRITE;
/*!40000 ALTER TABLE `paymentmethods` DISABLE KEYS */;
INSERT INTO `paymentmethods` VALUES (1,'COD','Cash On Delivery',1),(2,'VNPay','VNPay Gateway',1),(3,'Momo','Momo E-Wallet',1),(4,'Banking','Internet Banking',1),(5,'PayPal','PayPal Payment',1);
/*!40000 ALTER TABLE `paymentmethods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `PaymentId` int NOT NULL AUTO_INCREMENT,
  `OrderId` int NOT NULL,
  `PaymentMethodId` int NOT NULL,
  `PaymentStatus` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `TransactionCode` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `PaidAt` datetime DEFAULT NULL,
  PRIMARY KEY (`PaymentId`),
  KEY `FK_Payments_Methods` (`PaymentMethodId`),
  KEY `IX_Payments_OrderId` (`OrderId`),
  CONSTRAINT `FK_Payments_Methods` FOREIGN KEY (`PaymentMethodId`) REFERENCES `paymentmethods` (`PaymentMethodId`),
  CONSTRAINT `FK_Payments_Orders` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`OrderId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` VALUES (1,1,1,'Pending','COD001','2026-06-14 22:41:47'),(2,2,2,'Paid','VNP002','2026-06-14 22:41:47'),(3,3,3,'Paid','MOMO003','2026-06-14 22:41:47'),(4,4,1,'Cancelled','COD004','2026-06-14 22:41:47'),(5,5,4,'Paid','BANK005','2026-06-14 22:41:47');
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `ProductId` int NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(150) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Description` text COLLATE utf8mb4_unicode_ci,
  `Price` decimal(10,2) NOT NULL,
  `Stock` int DEFAULT '0',
  `Flavor` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Size` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Ingredients` text COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CategoryId` int NOT NULL,
  `ImageUrl` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ProductId`),
  KEY `IX_Products_CategoryId` (`CategoryId`),
  CONSTRAINT `FK_Products_Categories` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`CategoryId`),
  CONSTRAINT `CK_Product_Price` CHECK ((`Price` >= 0)),
  CONSTRAINT `CK_Product_Stock` CHECK ((`Stock` >= 0))
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Vanilla Sweet Cup','Vanilla edible waffle cup',21000.00,100,'Vanilla','Medium',1,'vanilla.jpg','2026-06-14 22:41:47'),(2,'Bamboo Sweet Cup','Chocolate edible waffle cup',23000.00,120,'Chocolate','Large',1,'chocolate.jpg','2026-06-14 22:41:47'),(3,'Matcha Sweet Cup','Matcha edible waffle cup',55000.00,80,'Matcha','Medium',1,'matcha.jpg','2026-06-14 22:41:47'),(4,'Strawberry Sweet Cup','Strawberry edible waffle cup',52000.00,90,'Strawberry','Small',1,'strawberry.jpg','2026-06-14 22:41:47'),(5,'Combo Family Pack','Combo 5 edible cups',109000.00,50,'Mixed','Large',2,'combo.jpg','2026-06-14 22:41:47');
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reviews`
--

DROP TABLE IF EXISTS `reviews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reviews` (
  `ReviewId` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `ProductId` int NOT NULL,
  `Rating` int NOT NULL,
  `Comment` varchar(500) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ImageUrl` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ReviewId`),
  KEY `FK_Reviews_Users` (`UserId`),
  KEY `IX_Reviews_ProductId` (`ProductId`),
  CONSTRAINT `FK_Reviews_Products` FOREIGN KEY (`ProductId`) REFERENCES `products` (`ProductId`),
  CONSTRAINT `FK_Reviews_Users` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`),
  CONSTRAINT `CK_Reviews_Rating` CHECK ((`Rating` between 1 and 5))
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reviews`
--

LOCK TABLES `reviews` WRITE;
/*!40000 ALTER TABLE `reviews` DISABLE KEYS */;
INSERT INTO `reviews` VALUES (1,1,1,5,'Very delicious and crispy','2026-06-14 22:41:47'),(2,2,2,4,'Chocolate flavor is great','2026-06-14 22:41:47'),(3,3,3,5,'Perfect with ice cream','2026-06-14 22:41:47'),(4,4,4,3,'Good but a bit sweet','2026-06-14 22:41:47'),(5,5,5,5,'Excellent combo pack','2026-06-14 22:41:47');
/*!40000 ALTER TABLE `reviews` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `RoleId` int NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`RoleId`),
  UNIQUE KEY `RoleName` (`RoleName`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Admin'),(2,'Customer'),(5,'Guest'),(4,'Manager'),(3,'Staff');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shipments`
--

DROP TABLE IF EXISTS `shipments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shipments` (
  `ShipmentId` int NOT NULL AUTO_INCREMENT,
  `OrderId` int NOT NULL,
  `TrackingCode` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Carrier` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Status` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ShippedAt` datetime DEFAULT NULL,
  `DeliveredAt` datetime DEFAULT NULL,
  `Note` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ShipmentId`),
  KEY `FK_Shipments_Orders` (`OrderId`),
  CONSTRAINT `FK_Shipments_Orders` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`OrderId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shipments`
--

LOCK TABLES `shipments` WRITE;
/*!40000 ALTER TABLE `shipments` DISABLE KEYS */;
INSERT INTO `shipments` VALUES (1,1,'SPX001234567','Giao Hàng Nhanh','Chờ lấy hàng',NULL,NULL,'Giao giờ hành chính, gọi trước khi đến','2026-06-14 22:41:47'),(2,2,'GRAB998877','GrabExpress','Đã giao hàng','2026-06-14 22:41:47','2026-06-14 22:41:47','Đồ ăn dễ vỡ, ship cẩn thận','2026-06-14 22:41:47'),(3,3,'GHTK10203040','Giao Hàng Tiết Kiệm','Đang vận chuyển','2026-06-14 22:41:47',NULL,'Nhà trong ngõ sâu','2026-06-14 22:41:47'),(4,4,NULL,'Ahamove','Đã hủy',NULL,NULL,'Khách hủy đơn do đổi ý','2026-06-14 22:41:47'),(5,5,'VTPOST776655','Viettel Post','Đã giao hàng','2026-06-14 22:41:47','2026-06-14 22:41:47','Khách hẹn giao buổi chiều','2026-06-14 22:41:47');
/*!40000 ALTER TABLE `shipments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shippingmethods`
--

DROP TABLE IF EXISTS `shippingmethods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shippingmethods` (
  `ShippingMethodId` int NOT NULL AUTO_INCREMENT,
  `MethodName` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Description` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ShippingFee` decimal(10,2) NOT NULL DEFAULT '0.00',
  `EstimatedDays` int NOT NULL DEFAULT '0',
  `IsActive` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`ShippingMethodId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shippingmethods`
--

LOCK TABLES `shippingmethods` WRITE;
/*!40000 ALTER TABLE `shippingmethods` DISABLE KEYS */;
INSERT INTO `shippingmethods` VALUES (1,'Hỏa tốc (Grab/Ahamove)','Giao hàng siêu tốc trong vòng 1-2 giờ áp dụng nội thành',35000.00,1,1),(2,'Giao hàng nhanh (GHN)','Vận chuyển toàn quốc từ 2 đến 3 ngày',22000.00,3,1),(3,'Giao hàng tiết kiệm (GHTK)','Chi phí tối ưu, thời gian từ 3 đến 5 ngày',15000.00,5,1),(4,'Viettel Post','Chuyển phát an toàn cho các khu vực huyện xã xa',18000.00,6,1),(5,'Nhận tại cửa hàng','Khách hàng tự đến chi nhánh gần nhất để lấy bánh',0.00,0,1);
/*!40000 ALTER TABLE `shippingmethods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useraddresses`
--

DROP TABLE IF EXISTS `useraddresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `useraddresses` (
  `AddressId` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `ReceiverName` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Phone` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Province` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `District` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Ward` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `AddressLine` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `IsDefault` tinyint(1) DEFAULT '0',
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`AddressId`),
  KEY `FK_UserAddresses_Users` (`UserId`),
  CONSTRAINT `FK_UserAddresses_Users` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraddresses`
--

LOCK TABLES `useraddresses` WRITE;
/*!40000 ALTER TABLE `useraddresses` DISABLE KEYS */;
INSERT INTO `useraddresses` VALUES (1,2,'Trần Thị B','0902222222','Thành phố Hải Phòng','Quận Ngô Quyền','Phường Máy Tơ','Số 12 Lê Thánh Tông',1,'2026-06-14 22:41:47'),(2,3,'Lê Văn C','0903333333','Thành phố Đà Nẵng','Quận Hải Châu','Phường Thạch Thang','Số 84 Nguyễn Chí Thanh',1,'2026-06-14 22:41:47'),(3,6,'Phạm Minh Tuấn','0911111111','Thành phố Hà Nội','Quận Cầu Giấy','Phường Dịch Vọng','Ngõ 165 Cầu Giấy, Số nhà 45',1,'2026-06-14 22:41:47'),(4,6,'Anh Tuấn (Văn phòng)','0911111111','Thành phố Hà Nội','Quận Nam Từ Liêm','Phường Mỹ Đình 2','Tòa nhà Keangnam, Tầng 12',0,'2026-06-14 22:41:47'),(5,7,'Nguyễn Thu Hà','0922222222','Tỉnh Hải Dương','Thành phố Hải Dương','Phường Quang Trung','Số 29 Đại lộ Hồ Chí Minh',1,'2026-06-14 22:41:47');
/*!40000 ALTER TABLE `useraddresses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `FullName` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Email` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `PasswordHash` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Phone` varchar(20) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Address` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `RoleId` int NOT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `Email` (`Email`),
  KEY `FK_Users_Roles` (`RoleId`),
  CONSTRAINT `FK_Users_Roles` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`RoleId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Nguyen Van A','a@gmail.com','123456','0901111111','Ha Noi',1,'2026-06-14 22:41:47'),(2,'Tran Thi B','b@gmail.com','123456','0902222222','Hai Phong',2,'2026-06-14 22:41:47'),(3,'Le Van C','c@gmail.com','123456','0903333333','Da Nang',2,'2026-06-14 22:41:47'),(4,'Pham Thi D','d@gmail.com','123456','0904444444','TP HCM',3,'2026-06-14 22:41:47'),(5,'Hoang Van E','e@gmail.com','123456','0905555555','Can Tho',4,'2026-06-14 22:41:47'),(6,'Pham Minh Tuan','tuan@gmail.com','123456','0911111111','Ha Noi',2,'2026-06-14 22:41:47'),(7,'Nguyen Thu Ha','thuha@gmail.com','123456','0922222222','Hai Duong',2,'2026-06-14 22:41:47'),(8,'Tran Quoc Bao','quocbao@gmail.com','123456','0933333333','Nam Dinh',2,'2026-06-14 22:41:47'),(9,'Le Ngoc Anh','ngocanh@gmail.com','123456','0944444444','Nghe An',2,'2026-06-14 22:41:47'),(10,'Do Thanh Huyen','thanhhuyen@gmail.com','123456','0955555555','Hue',2,'2026-06-14 22:41:47');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wishlists`
--

DROP TABLE IF EXISTS `wishlists`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `wishlists` (
  `WishlistId` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `ProductId` int NOT NULL,
  `AddedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`WishlistId`),
  KEY `FK_Wishlists_Users` (`UserId`),
  KEY `FK_Wishlists_Products` (`ProductId`),
  CONSTRAINT `FK_Wishlists_Products` FOREIGN KEY (`ProductId`) REFERENCES `products` (`ProductId`),
  CONSTRAINT `FK_Wishlists_Users` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wishlists`
--

LOCK TABLES `wishlists` WRITE;
/*!40000 ALTER TABLE `wishlists` DISABLE KEYS */;
INSERT INTO `wishlists` VALUES (1,2,3,'2026-06-14 22:41:47'),(2,3,1,'2026-06-14 22:41:47'),(3,6,2,'2026-06-14 22:41:47'),(4,7,5,'2026-06-14 22:41:47'),(5,8,4,'2026-06-14 22:41:47');
/*!40000 ALTER TABLE `wishlists` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-06-15 20:54:21
