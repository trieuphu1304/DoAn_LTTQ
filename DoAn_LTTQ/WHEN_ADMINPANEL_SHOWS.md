# 🎯 KHI NÀO ADMINPANEL SẼ HIỂN THỊ?

## 📊 SƠĐỒ FLOW:

```
┌─────────────────────────────────────────┐
│  Mở Ứng Dụng (Master_Layout)           │
│  - Tất cả menu bị vô hiệu hóa (mờ đi) │
└──────────┬──────────────────────────────┘
           ↓
┌─────────────────────────────────────────┐
│  Click "Hệ thống" → "Đăng nhập"        │
│  → LoginForm xuất hiện                  │
└──────────┬──────────────────────────────┘
           ↓
┌─────────────────────────────────────────┐
│  Nhập Username & Password               │
│  Click "Đăng nhập"                      │
└──────────┬──────────────────────────────┘
           ↓
┌─────────────────────────────────────────┐
│  LOGIN PROCESS:                         │
│  1. Lấy tất cả tài khoản từ Database    │
│  2. Tìm tài khoản phù hợp               │
│  3. Kiểm tra Type                       │
└──────────┬──────────────────────────────┘
           ↓
     ┌─────┴─────┐
     ↓           ↓
┌──────────┐  ┌──────────────────────┐
│Type = 2  │  │ Type = 0 hoặc 1      │
│(Quản lý) │  │ (Admin/Nhân viên)    │
└────┬─────┘  └──────────┬───────────┘
     ↓                   ↓
┌──────────────────┐  ┌──────────────────┐
│ Tạo AdminPanel   │  │ Bật tất cả menu  │
│ Hiển thị nó      │  │ của Master_Layout│
│ Ẩn Master_Layout │  │                  │
└─────┬────────────┘  └────────┬─────────┘
      ↓                        ↓
   ADMINPANEL           MASTER_LAYOUT
   HIỂN THỊ            SỬ DỤNG BÌNH THƯỜNG
```

---

## ✅ ĐIỀU KIỆN ADMINPANEL HIỂN THỊ:

### ✓ Điều Kiện 1: Tài Khoản Phù Hợp
```
Database phải có tài khoản với:
- UserName = Giá trị bạn nhập
- Password = Giá trị bạn nhập (chính xác)
- Type = 2 (Quản lý)
```

### ✓ Điều Kiện 2: Database Connection
```
- Server: LAPTOP-0G3MKQED\SQLEXPRESS
- Database: QuanLyNhaHang
- User: sa
- Password: 123456
- Phải kết nối được
```

### ✓ Điều Kiện 3: AdminPanel.Load() Không Lỗi
```
Khi AdminPanel load, nó sẽ:
- LoadFoodCategories()
- LoadAccountRoles()
- InitializeEmployeeTab()
- InitializeCategoryTab()
- LoadAllData()

Tất cả không được lỗi
```

### ✓ Điều Kiện 4: Chạy Ở Debug Mode
```
Bấm F5, KHÔNG phải Ctrl+F5
Để thấy debug output trong Output window
```

---

## 🔍 CÁC BƯỚC ADMINPANEL HIỂN THỊ:

```
Step 1: LoginForm xác minh tài khoản từ DB
        ↓ (Nếu OK → Step 2)

Step 2: Master_Layout nhận Account với Type=2
        ↓ (Nếu Type==2 → Step 3)

Step 3: Tạo AdminPanel instance mới
        ↓ (Nếu không lỗi → Step 4)

Step 4: Gán FormClosed event handler
        ↓ (Để xử lý khi AdminPanel đóng)

Step 5: Gọi adminPanelInstance.Show()
        ↓ (AdminPanel sẽ hiển thị)

Step 6: Gọi this.Hide() (Master_Layout ẩn)
        ↓

✅ ADMINPANEL HIỂN THỊ THÀNH CÔNG
```

---

## ⚠️ ĐIỂM KHÁC BIỆT QUAN TRỌNG:

### Tài Khoản Type = 2 (Quản lý):
```
Hành Động: Đăng Nhập
→ Master_Layout sẽ ẨN
→ AdminPanel sẽ HIỂN THỊ (Full quản lý)
```

### Tài Khoản Type = 1 (Nhân viên):
```
Hành Động: Đăng Nhập
→ Master_Layout sẽ HIỂN THỊ
→ Tất cả menu sẽ BẬT (được sử dụng)
→ AdminPanel KHÔNG hiển thị
```

### Tài Khoản Type = 0 (Admin):
```
Hành Động: Đăng Nhập
→ Master_Layout sẽ HIỂN THỊ
→ Tất cả menu sẽ BẬT (được sử dụng)
→ AdminPanel KHÔNG hiển thị
```

---

## 📋 CHECKLIST TRƯỚC KHI CHẠY:

```
☐ Database QuanLyNhaHang tồn tại
☐ Bảng Account có dữ liệu
☐ Có tài khoản với Type = 2
☐ Biết username/password của tài khoản Type = 2
☐ Database connection string đúng
☐ Build Solution thành công
☐ Output window đã sẵn sàng
☐ Sẽ chạy F5 (Debug mode)
```

---

## 🚀 CÁC BƯỚC CHẠY NGAY BÂY GIỜ:

### 1. Kiểm Tra Database
```sql
SELECT * FROM Account WHERE Type = 2;
-- Phải có ít nhất 1 kết quả
```

### 2. Chạy Ứng Dụng
```
Bấm F5 trong Visual Studio
```

### 3. Đăng Nhập
```
Click "Hệ thống" → "Đăng nhập"
Nhập tài khoản Type = 2
Click "Đăng nhập"
```

### 4. Xem Kết Quả
```
AdminPanel sẽ hiển thị nếu mọi thứ OK
Master_Layout sẽ ẩn
```

---

## 💡 NẾU ADMINPANEL VẪN KHÔNG HIỂN THỊ:

**Hãy xem Output window và tìm dòng nào có sự cố:**

1. **"Không tìm thấy tài khoản phù hợp"**
   → Sai username/password hoặc Type ≠ 2

2. **"Type không khớp"**
   → Bạn dùng tài khoản Type=1 hoặc 0, cần Type=2

3. **"Exception trong khối try"**
   → AdminPanel.Load() có lỗi
   → Xem chi tiết lỗi trong Output

4. **Không có debug message**
   → Chạy ở Release mode (Ctrl+F5) thay vì Debug (F5)
   → Bấm F5 để chạy Debug mode

---

## ✨ TỔNG KẾT:

AdminPanel sẽ hiển thị khi:
1. ✅ Đăng nhập tài khoản Type = 2
2. ✅ Database có tài khoản đó
3. ✅ Username/Password khớp
4. ✅ AdminPanel.Load() không lỗi
5. ✅ Không có exception nào

**Nếu 1 trong 5 điều kiện trên không thỏa, AdminPanel sẽ không hiển thị!**

---

**Hãy kiểm tra từng điều kiện, output sẽ cho bạn biết điều kiện nào bị vi phạm!**
