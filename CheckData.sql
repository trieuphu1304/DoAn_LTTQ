-- =========================================================
-- KIỂM TRA DỮ LIỆU TRONG DATABASE QuanLyNhaHang
-- =========================================================
-- Chạy script này để xác nhận dữ liệu đã được thêm

USE QuanLyNhaHang
GO

PRINT '========== KIỂM TRA DANH MỤC =========='
SELECT ID, Name FROM FoodCategory ORDER BY ID
PRINT ''

PRINT '========== KIỂM TRA BÀNS =========='
SELECT ID, Name, Status FROM TableFood ORDER BY ID
PRINT ''

PRINT '========== KIỂM TRA DANH SÁCH MÓN ĂN =========='
SELECT 
    f.ID, 
    f.Name, 
    fc.Name AS [Danh Mục], 
    f.Price AS [Giá]
FROM Food f
JOIN FoodCategory fc ON f.CategoryID = fc.ID
ORDER BY fc.ID, f.Name
PRINT ''

PRINT '========== THỐNG KÊ =========='
SELECT 
    (SELECT COUNT(*) FROM TableFood) AS [Số bàn],
    (SELECT COUNT(*) FROM Food) AS [Số món ăn],
    (SELECT COUNT(*) FROM FoodCategory) AS [Số danh mục],
    (SELECT COUNT(*) FROM Bill) AS [Số hóa đơn]
PRINT ''

PRINT '========== KIỂM TRA HÓAS ĐƠN (nếu có) =========='
SELECT 
    b.ID,
    tf.Name AS [Bàn],
    b.DateCheckIn,
    b.DateCheckOut,
    b.Status,
    SUM(bi.Count * f.Price) AS [Tổng tiền]
FROM Bill b
LEFT JOIN TableFood tf ON b.TableID = tf.ID
LEFT JOIN BillInfo bi ON b.ID = bi.BillID
LEFT JOIN Food f ON bi.FoodID = f.ID
GROUP BY b.ID, tf.Name, b.DateCheckIn, b.DateCheckOut, b.Status
PRINT ''

PRINT '✅ KIỂM TRA HOÀN TẤT!'
