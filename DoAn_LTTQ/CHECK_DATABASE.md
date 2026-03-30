# 🔍 KIỂM TRA DATABASE NHANH

## 1️⃣ Bạn Nên Kiểm Tra Ngay Bây GIỜ:

### Mở SQL Server Management Studio
```
1. Mở SQL Server Management Studio
2. Connect đến: LAPTOP-0G3MKQED\SQLEXPRESS
3. Username: sa
4. Password: 123456
5. Chọn Database: QuanLyNhaHang
```

### Chạy Query Này:
```sql
SELECT UserName, DisplayName, Password, Type, EmployeeID 
FROM Account;
```

**Kết Quả mà bạn nên thấy:**
```
UserName      DisplayName    Password    Type    EmployeeID
-----------   -------        -------     ----    ----------
quanly01      Quản Lý 1      pass123     2       NULL
nhanvien01    Nhân Viên 1    pass456     1       1
admin01       Admin          admin123    0       NULL
```

---

## 2️⃣ Kiểm Tra Type của Tài Khoản:

```sql
-- Xem tài khoản Type = 2 (Quản lý)
SELECT * FROM Account WHERE Type = 2;

-- Xem tài khoản Type = 1 (Nhân viên)
SELECT * FROM Account WHERE Type = 1;

-- Xem tài khoản Type = 0 (Admin)
SELECT * FROM Account WHERE Type = 0;
```

---

## 3️⃣ Nếu Không Có Tài Khoản Type = 2:

### Thêm Tài Khoản Quản Lý:
```sql
INSERT INTO Account (UserName, DisplayName, Password, Type, EmployeeID)
VALUES ('quanly01', 'Quản Lý 1', 'password123', 2, NULL);
```

### Thêm Tài Khoản Nhân Viên:
```sql
INSERT INTO Account (UserName, DisplayName, Password, Type, EmployeeID)
VALUES ('nhanvien01', 'Nhân Viên 1', 'password456', 1, 1);
```

---

## 4️⃣ Nếu Muốn Sửa Type của Tài Khoản Hiện Có:

```sql
-- Sửa tài khoản bất kỳ thành quản lý
UPDATE Account SET Type = 2 WHERE UserName = 'quanly01';

-- Sửa tài khoản bất kỳ thành nhân viên
UPDATE Account SET Type = 1 WHERE UserName = 'nhanvien01';

-- Sửa tài khoản bất kỳ thành admin
UPDATE Account SET Type = 0 WHERE UserName = 'admin01';
```

---

## 5️⃣ Xem Cấu Trúc Bảng Account:

```sql
-- Xem tất cả tài khoản
SELECT * FROM Account;

-- Xem số lượng tài khoản
SELECT COUNT(*) as SoTaiKhoan FROM Account;

-- Xem thống kê theo Type
SELECT Type, COUNT(*) as SoTaiKhoan FROM Account GROUP BY Type;
```

---

## ✅ Đảm Bảo:

✓ Database `QuanLyNhaHang` tồn tại  
✓ Bảng `Account` tồn tại  
✓ Có ít nhất 1 tài khoản Type = 2 (Quản lý)  
✓ Password chính xác  
✓ Connection string trong `DatabaseConnection.cs` đúng  

---

## 🚀 Sau Khi Kiểm Tra Database:

1. Chắc chắn bạn có tài khoản Type = 2
2. Ghi nhớ UserName và Password
3. Chạy ứng dụng
4. Đăng nhập bằng tài khoản Type = 2 đó
5. AdminPanel sẽ hiển thị

---

## 💡 Connection String (Nếu Cần Kiểm Tra):

File: `DoAn_LTTQ\Data\DatabaseConnection.cs`

```csharp
private static string connectionString = 
    "Server=LAPTOP-0G3MKQED\\SQLEXPRESS;" +
    "Database=QuanLyNhaHang;" +
    "User Id=sa;" +
    "Password=123456;";
```

**Chắc chắn server name và database name đúng!**
