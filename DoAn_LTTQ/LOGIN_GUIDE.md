# Hướng Dẫn Sử Dụng Giao Diện Đăng Nhập

## Tính Năng Mới

Dự án đã được cập nhật với giao diện đăng nhập hoàn chỉnh. Dưới đây là hướng dẫn chi tiết:

### 1. Giao Diện Khởi Động
- Khi khởi động ứng dụng, `Master_Layout` sẽ hiển thị
- Tất cả các menu (Danh mục, Hóa đơn, Báo cáo, Thông tin, Trợ giúp) sẽ bị **vô hiệu hóa** (mờ đi)
- Chỉ menu "Hệ thống" được bật, cho phép người dùng đăng nhập

### 2. Giao Diện Đăng Nhập
Giao diện đăng nhập gồm:
- **Trường "Tài khoản"**: Nhập tên tài khoản
- **Trường "Mật khẩu"**: Nhập mật khẩu (ký tự sẽ hiển thị dưới dạng *)
- **Button "Đăng nhập"**: Xác nhận đăng nhập
- **Button "Hủy"**: Đóng giao diện mà không đăng nhập

### 3. Quy Trình Đăng Nhập

#### Nếu Đăng Nhập Tài Khoản "Quản lý" (Type = 2)
1. Nhập tên tài khoản và mật khẩu của tài khoản quản lý
2. Nhấn "Đăng nhập"
3. Kết quả:
   - Giao diện `Master_Layout` sẽ **ẩn đi**
   - Giao diện `AdminPanel` sẽ **hiển thị**
   - Bạn sẽ có quyền quản lý toàn bộ hệ thống

#### Nếu Đăng Nhập Tài Khoản "Nhân viên" (Type = 1)
1. Nhập tên tài khoản và mật khẩu của tài khoản nhân viên
2. Nhấn "Đăng nhập"
3. Kết quả:
   - Giao diện `Master_Layout` vẫn **hiển thị**
   - Tất cả các menu sẽ **được bật** (không còn mờ)
   - Bạn có thể sử dụng bình thường

### 4. Quy Trình Đăng Xuất
- Click vào menu "Hệ thống" > "Đăng xuất"
- Tất cả menu sẽ bị vô hiệu hóa lại
- Bạn quay lại giao diện ban đầu và có thể đăng nhập lại

### 5. Thoát Ứng Dụng
- Click vào menu "Hệ thống" > "Thoát"
- Sẽ hiển thị hộp xác nhận
- Nhấn "Yes" để thoát, "No" để hủy

## Điều Kiện Đăng Nhập
- Tài khoản phải tồn tại trong cơ sở dữ liệu
- Mật khẩu phải chính xác
- Tài khoản sẽ được xác minh từ bảng `Account` trong database

## Lưu Ý Quan Trọng
- **Không có sửa đổi về code gốc**: Toàn bộ chức năng đăng nhập là code mới được thêm vào
- Các file mới được tạo:
  - `LoginForm.cs`: Form đăng nhập (logic)
  - `LoginForm.Designer.cs`: Form đăng nhập (giao diện)
- Các file được chỉnh sửa:
  - `Master_Layout.cs`: Thêm logic xử lý đăng nhập
  - `Master_Layout.Designer.cs`: Thêm event handlers

## Cách Thêm Tài Khoản Test
Nếu bạn cần thêm tài khoản test vào database:
```sql
INSERT INTO Account (UserName, DisplayName, Password, Type, EmployeeID)
VALUES ('quanly01', 'Quản Lý 1', 'password123', 2, NULL);

INSERT INTO Account (UserName, DisplayName, Password, Type, EmployeeID)
VALUES ('nhanvien01', 'Nhân Viên 1', 'password456', 1, 1);
```

**Type 0**: Admin  
**Type 1**: Nhân viên  
**Type 2**: Quản lý  
