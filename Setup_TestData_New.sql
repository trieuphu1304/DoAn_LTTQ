-- ========== CLEAR EXISTING DATA ==========
DELETE FROM BillInfo;
DELETE FROM Bill;
DELETE FROM Food;
DELETE FROM TableFood;
DELETE FROM FoodCategory;

-- ========== INSERT FOOD CATEGORIES ==========
INSERT INTO FoodCategory(Name) VALUES
(N'Món chính'),
(N'Nước uống'),
(N'Tráng miệng');

-- ========== INSERT FOOD ITEMS ==========
INSERT INTO Food(Name, CategoryID, Price) VALUES
-- Món chính
(N'Cơm chiên hải sản', 1, 55000),
(N'Cơm chiên gà', 1, 45000),
(N'Phở bò', 1, 40000),
(N'Phở gà', 1, 35000),
(N'Bún riêu cua', 1, 30000),
(N'Mì Ý sốt cà chua', 1, 50000),
(N'Gà nướng tiêu', 1, 65000),
(N'Cá nướng chanh', 1, 70000),
(N'Tôm hút trứng', 1, 75000),
(N'Lẩu hải sản', 1, 120000),
-- Nước uống
(N'Nước cam ép', 2, 15000),
(N'Nước dâu ép', 2, 15000),
(N'Sinh tố dâu', 2, 20000),
(N'Sinh tố xoài', 2, 20000),
(N'Bia Tiger', 2, 25000),
(N'Bia Heineken', 2, 25000),
(N'Coca Cola', 2, 8000),
(N'Sprite', 2, 8000),
(N'Nước lọc', 2, 3000),
(N'Trà đá', 2, 5000),
(N'Cà phê đen', 2, 12000),
(N'Cà phê sữa', 2, 15000),
-- Tráng miệng
(N'Chè ba màu', 3, 18000),
(N'Kem vani', 3, 25000),
(N'Kem chocolate', 3, 25000),
(N'Bánh flan', 3, 12000),
(N'Bánh tiramisu', 3, 20000);

-- ========== INSERT TABLES (10 tables) ==========
-- 3 bàn đang sử dụng, 7 bàn còn trống
INSERT INTO TableFood(Name, Status) VALUES
(N'Bàn 1', N'Trống'),
(N'Bàn 2', N'Sử dụng'),
(N'Bàn 3', N'Sử dụng'),
(N'Bàn 4', N'Trống'),
(N'Bàn 5', N'Trống'),
(N'Bàn 6', N'Trống'),
(N'Bàn 7', N'Sử dụng'),
(N'Bàn 8', N'Trống'),
(N'Bàn 9', N'Trống'),
(N'Bàn 10', N'Trống');

-- ========== INSERT SAMPLE BILLS (Hóa đơn mẫu - đang sử dụng) ==========
-- Bill 1: Bàn 2 đang sử dụng (Status = 0)
INSERT INTO Bill(DateCheckIn, TableID, Status) 
VALUES(GETDATE(), 2, 0);

-- Bill 2: Bàn 3 đang sử dụng (Status = 0)
INSERT INTO Bill(DateCheckIn, TableID, Status) 
VALUES(GETDATE(), 3, 0);

-- Bill 3: Bàn 7 đang sử dụng (Status = 0)
INSERT INTO Bill(DateCheckIn, TableID, Status) 
VALUES(GETDATE(), 7, 0);

-- ========== INSERT BILL DETAILS ==========
-- Bàn 2: Cơm chiên gà (2) + Bia Tiger (1) + Nước cam (1) = 90k + 25k + 15k = 130k
INSERT INTO BillInfo(BillID, FoodID, Count) VALUES
(1, 2, 2),
(1, 16, 1),
(1, 11, 1);

-- Bàn 3: Phở bò (1) + Sinh tố dâu (2) + Kem vani (1) = 40k + 40k + 25k = 105k
INSERT INTO BillInfo(BillID, FoodID, Count) VALUES
(2, 3, 1),
(2, 13, 2),
(2, 24, 1);

-- Bàn 7: Mì Ý (1) + Cà phê sữa (3) + Bánh flan (2) = 50k + 45k + 24k = 119k
INSERT INTO BillInfo(BillID, FoodID, Count) VALUES
(3, 6, 1),
(3, 22, 3),
(3, 26, 2);

-- ========== VERIFY DATA ==========
PRINT '=== DỮ LIỆU ĐÃ CÀI ĐẶT THÀNH CÔNG ==='
SELECT COUNT(*) AS [Số Bàn] FROM TableFood;
SELECT COUNT(*) AS [Số Món] FROM Food;
SELECT COUNT(*) AS [Số Danh Mục] FROM FoodCategory;
SELECT COUNT(*) AS [Số Hóa Đơn Đang Sử Dụng] FROM Bill WHERE Status = 0;

PRINT ''
PRINT '=== DANH SÁCH BÀN ==='
SELECT ID, Name, Status FROM TableFood ORDER BY ID;

PRINT ''
PRINT '=== HÓASSƠN ĐANG SỬ DỤNG ==='
SELECT b.ID, tf.Name AS [Bàn], b.DateCheckIn, SUM(bi.Count * f.Price) AS [Tổng Tiền]
FROM Bill b
LEFT JOIN TableFood tf ON b.TableID = tf.ID
LEFT JOIN BillInfo bi ON b.ID = bi.BillID
LEFT JOIN Food f ON bi.FoodID = f.ID
WHERE b.Status = 0
GROUP BY b.ID, tf.Name, b.DateCheckIn;
