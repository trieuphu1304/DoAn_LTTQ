# 🔍 HƯỚNG DẪN DEBUG ADMINPANEL KHÔNG HIỂN THỊ

## 📌 Các Bước Debug:

### Bước 1: Mở Output Window
```
Debug → Windows → Output
hoặc Ctrl + Alt + O
```

### Bước 2: Chạy Ứng Dụng (Debug Mode)
```
F5 hoặc Debug → Start Debugging
```

### Bước 3: Thực Hiện Các Step Sau:
1. Click "Hệ thống" → "Đăng nhập"
2. Nhập tài khoản quản lý (Type = 2)
3. Nhập mật khẩu
4. Click "Đăng nhập"

### Bước 4: Xem Output Console
Tìm những dòng bắt đầu với `DEBUG:` hoặc `Error:`

---

## 📋 Các Output Mà Bạn Sẽ Thấy:

### ✅ Nếu Thành Công (AdminPanel Sẽ Hiển Thị):
```
DEBUG Login: Username = 'quanly01', Password = 'password123'
DEBUG: Tìm thấy [X] tài khoản trong database
DEBUG: Account - UserName='quanly01', DisplayName='Quản Lý 1', Type=2
DEBUG: Tài khoản khớp! Type = 2
DEBUG: Đăng nhập thành công, Type = 2
DEBUG: Vào vòng lặp Type = 2 (Quản lý)
DEBUG: Bắt đầu tạo AdminPanel
DEBUG: AdminPanel đã tạo
DEBUG: Gọi adminPanelInstance.Show()
DEBUG: Ẩn Master_Layout
DEBUG: Xong, AdminPanel đã được hiển thị
```

### ❌ Nếu Lỗi (Tìm Dòng Error):
```
DEBUG: Exception trong khối try: [CHI TIẾT LỖI]
```

---

## 🔧 Các Tình Huống Có Thể Gặp:

### Tình Huống 1: "Không tìm thấy tài khoản phù hợp"
```
DEBUG: Tìm thấy [X] tài khoản trong database
DEBUG: Không tìm thấy tài khoản phù hợp
```
**Nguyên Nhân**: 
- Username hoặc password sai
- Tài khoản không có trong database

**Giải Pháp**:
- Kiểm tra database xem có tài khoản Type=2 không
- Xem đúng username/password không
- Chạy query SQL:
  ```sql
  SELECT UserName, Password, Type FROM Account WHERE Type = 2;
  ```

---

### Tình Huống 2: "Type không khớp"
```
DEBUG: Vào vòng lặp Type = 1 (Nhân viên)
// thay vì Type = 2
```
**Nguyên Nhân**: 
- Tài khoản bạn đang dùng có Type ≠ 2

**Giải Pháp**:
- Dùng tài khoản có Type = 2 (Quản lý)
- Hoặc thay đổi Type trong database:
  ```sql
  UPDATE Account SET Type = 2 WHERE UserName = 'quanly01';
  ```

---

### Tình Huống 3: "Exception trong khối try"
```
DEBUG: Exception trong khối try: System.NullReferenceException...
```
**Nguyên Nhân**: 
- AdminPanel.Load() có lỗi khi load dữ liệu
- Hoặc control không tồn tại

**Giải Pháp**:
- Xem chi tiết lỗi trong Output window
- Kiểm tra database connection
- Kiểm tra các DAL class (FoodCategoryDAL, v.v.)

---

## 📊 Cách Kiểm Tra Database:

### Query để Kiểm Tra Tài Khoản:
```sql
-- Xem tất cả tài khoản
SELECT UserName, DisplayName, Password, Type FROM Account;

-- Xem chỉ tài khoản quản lý
SELECT * FROM Account WHERE Type = 2;

-- Xem chỉ tài khoản nhân viên
SELECT * FROM Account WHERE Type = 1;
```

### Thêm Tài Khoản Test:
```sql
-- Thêm tài khoản quản lý
INSERT INTO Account (UserName, DisplayName, Password, Type)
VALUES ('quanly01', 'Quản Lý 1', 'password123', 2);

-- Thêm tài khoản nhân viên
INSERT INTO Account (UserName, DisplayName, Password, Type)
VALUES ('nhanvien01', 'Nhân Viên 1', 'password456', 1);
```

---

## 🎯 Checklist Debug:

- [ ] Output window đã mở
- [ ] Chạy ứng dụng ở Debug mode (F5)
- [ ] Thấy debug output trong Output window
- [ ] Tìm dòng "Tài khoản khớp"
- [ ] Tìm dòng "Vào vòng lặp Type = 2"
- [ ] Không có dòng Exception
- [ ] AdminPanel hiển thị

---

## ⚡ Nếu Vẫn Không Hiển Thị:

1. **Copy toàn bộ output từ Output window** 
2. **Dán cho tôi xem**
3. Tôi sẽ tìm ra vấn đề chính xác

---

**Quan trọng**: Hãy chạy lại ứng dụng bằng **F5** (Debug mode), không phải Ctrl+F5 (Release mode)
