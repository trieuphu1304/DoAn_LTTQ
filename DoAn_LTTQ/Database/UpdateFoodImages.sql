-- Script cập nhật ImagePath cho các món ăn

UPDATE Food SET ImagePath = N'Images/tra_da.jpg' WHERE Name = N'Trà Đá'
UPDATE Food SET ImagePath = N'Images/com_chien.jpg' WHERE Name = N'Cơm chiên'
UPDATE Food SET ImagePath = N'Images/pho_bo.jpg' WHERE Name = N'Phở bò'

PRINT N'Đã cập nhật ImagePath thành công!'
