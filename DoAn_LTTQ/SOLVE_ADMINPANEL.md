# 🆘 HƯỚNG DẪN GIẢI QUYẾT ADMINPANEL KHÔNG HIỂN THỊ

## ⚠️ ĐIỀU QUAN TRỌNG NHẤT:

Tôi đã thêm **Debug Output** vào code để bạn có thể xem chính xác điều gì đang xảy ra.

---

## 🎯 Các Bước Thực Hiện:

### **BƯỚC 1**: Kiểm Tra Database (LÀM TRƯỚC TIÊN)

Mở SQL Server Management Studio và chạy:
```sql
SELECT UserName, DisplayName, Password, Type FROM Account;
```

**Bạn PHẢI có ít nhất 1 tài khoản với Type = 2**

Nếu không có, chạy:
```sql
INSERT INTO Account (UserName, DisplayName, Password, Type)
VALUES ('quanly01', 'Quản Lý 1', 'password123', 2);
```

---

### **BƯỚC 2**: Chạy Ứng Dụng Ở DEBUG MODE

**⚠️ QUAN TRỌNG: Bấm F5, KHÔNG phải Ctrl+F5**

```
F5 → Ứng dụng sẽ chạy ở debug mode
```

---

### **BƯỚC 3**: Mở Output Window

Trong Visual Studio:
```
Debug → Windows → Output
hoặc Ctrl + Alt + O
```

---

### **BƯỚC 4**: Thực Hiện Đăng Nhập

1. Click "Hệ thống" → "Đăng nhập"
2. Nhập Username: `quanly01` (hoặc tài khoản Type=2 của bạn)
3. Nhập Password: `password123` (hoặc mật khẩu của bạn)
4. Click "Đăng nhập"

---

### **BƯỚC 5**: Xem Output Window

Bạn sẽ thấy các dòng DEBUG như:

```
DEBUG Login: Username = 'quanly01', Password = 'password123'
DEBUG: Tìm thấy 3 tài khoản trong database
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

---

## ✅ Khi Nào AdminPanel Sẽ Hiển Thị?

AdminPanel sẽ hiển thị khi **TẤT CẢ** những dòng trên xuất hiện **KHÔNG CÓ LỖI**.

---

## ❌ Nếu Gặp Lỗi:

### Lỗi 1: "Không tìm thấy tài khoản phù hợp"
```
DEBUG: Không tìm thấy tài khoản phù hợp
```

**Giải pháp:**
- Kiểm tra username/password có đúng không?
- Kiểm tra Database có tài khoản Type=2 không?

### Lỗi 2: "Type không khớp"
```
DEBUG: Vào vòng lặp Type = 1 (Nhân viên)
// thay vì Type = 2
```

**Giải pháp:**
- Bạn đang dùng tài khoản nhân viên (Type=1)
- Cần dùng tài khoản quản lý (Type=2)

### Lỗi 3: "Exception trong khối try"
```
DEBUG: Exception trong khối try: System.XXXException...
```

**Giải pháp:**
- Có vấn đề khi AdminPanel load dữ liệu
- Xem chi tiết exception trong Output
- Kiểm tra database connection

---

## 🔧 Nếu Vẫn Không Hiển Thị:

**Hãy copy toàn bộ OUTPUT từ Console và gửi cho tôi, bao gồm:**
- Dòng bắt đầu với "DEBUG:"
- Dòng "Exception" nếu có
- Dòng "Error:" nếu có

---

## 📋 Danh Sách Kiểm Tra Trước Khi Debug:

- [ ] Database QuanLyNhaHang tồn tại
- [ ] Bảng Account có dữ liệu
- [ ] Có ít nhất 1 tài khoản Type = 2
- [ ] Biết chính xác username/password của tài khoản Type = 2
- [ ] Build project thành công (Build → Build Solution)
- [ ] Chạy ở Debug Mode (F5, không phải Ctrl+F5)
- [ ] Output window đã mở

---

## 💡 Tips Quan Trọng:

1. **Luôn chạy F5** - Để thấy debug output
2. **Kiểm tra Database trước** - Chắc chắn có tài khoản Type=2
3. **Xem Output cẩn thận** - Dòng nào lỗi?
4. **Copy error message** - Gửi cho tôi xem chi tiết

---

**Hãy làm theo các bước trên, output sẽ cho bạn biết chính xác vấn đề ở đâu!**
