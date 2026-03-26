-- ========== RESET TẤT CẢ BÀN VỀ TRỐNG ==========
-- Xóa tất cả hóa đơn & chi tiết để reset lại
USE QuanLyNhaHang
GO

PRINT '========== RESET HỆ THỐNG ==========';

-- Xóa tất cả chi tiết hóa đơn
DELETE FROM BillInfo;

-- Xóa tất cả hóa đơn
DELETE FROM Bill;

-- Đặt tất cả bàn về trống
UPDATE TableFood SET Status = N'Trống';

-- Reset identity cho các bảng
DBCC CHECKIDENT (Bill, RESEED, 0);
DBCC CHECKIDENT (BillInfo, RESEED, 0);

PRINT '========== RESET HOÀN TẤT ==========';

PRINT '';
PRINT 'Trạng thái sau reset:';
SELECT 
    (SELECT COUNT(*) FROM TableFood WHERE Status = N'Trống') AS [Bàn Trống],
    (SELECT COUNT(*) FROM TableFood WHERE Status = N'Sử dụng') AS [Bàn Sử Dụng],
    (SELECT COUNT(*) FROM Bill WHERE Status = 0) AS [Hóa Đơn Đang Hoạt Động];

PRINT '';
PRINT '✅ Sẵn sàng! Các bàn đã reset, khi đặt món sẽ tự động chuyển sang "Đang sử dụng"';
