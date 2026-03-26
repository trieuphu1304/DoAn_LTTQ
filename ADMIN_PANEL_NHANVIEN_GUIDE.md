# Giao Diện Quản Lý Nhân Viên trong Admin Panel

## 📋 Tổng Quan

Đã thêm tab **"Nhân Viên"** vào Admin Panel với đầy đủ chức năng CRUD giống như form QLNhanVien.

## ✨ Tính Năng

### 1. **Thêm Nhân Viên Mới** (Thêm)
- Nhập thông tin vào các ô:
  - **Tên nhân viên**: Bắt buộc
  - **Số điện thoại**: Bắt buộc
  - **Vị trí**: Bắt buộc
  - **Lương**: Bắt buộc
  - **Ảnh đại diện**: Chọn bằng nút "Chọn ảnh" (không bắt buộc)
- Nhấn nút **"Thêm"** để lưu vào database
- Dữ liệu tự động hiển thị ở DataGridView

### 2. **Xem Thông Tin Nhân Viên**
- Nhấn vào bất kỳ hàng nào trong DataGridView
- Thông tin nhân viên được hiển thị tự động trong các ô nhập liệu ở trên

### 3. **Sửa Thông Tin Nhân Viên** (Sửa)
- Chọn nhân viên từ DataGridView
- Sửa thông tin trong các ô nhập liệu
- (Tùy chọn) Chọn ảnh mới
- Nhấn nút **"Sửa"** để cập nhật vào database
- DataGridView tự động cập nhật

### 4. **Xóa Nhân Viên** (Xóa)
- Chọn nhân viên từ DataGridView
- Nhấn nút **"Xóa"**
- Xác nhận xóa trong hộp thoại
- Nhân viên bị xóa từ database và DataGridView

### 5. **Chọn Ảnh Đại Diện**
- Nhấn nút **"Chọn ảnh"** trong phần "Ảnh đại diện"
- Chọn file ảnh từ máy tính (.jpg, .png, .bmp)
- Đường dẫn ảnh được lưu cùng với thông tin nhân viên

### 6. **Tải Lại Dữ Liệu** (Tải lại)
- Nhấn nút **"Tải lại"** để refresh dữ liệu từ database
- Xóa các ô nhập liệu
- Cập nhật DataGridView

## 🏗️ Cấu Trúc Giao Diện

```
┌─────────────────────────────────────────────────────────┐
│  QUẢN LÍ NHÂN VIÊN                          (Header)    │
├─────────────────────────────────────────────────────────┤
│  Tên nhân viên:  [      ]   Lương:         [      ]     │
│  Số điện thoại:  [      ]   Vị trí:        [      ]     │
│  Ảnh đại diện:   [Chọn ảnh]                             │
├─────────────────────────────────────────────────────────┤
│ [Thêm] [Sửa] [Xóa] [Tải lại]     (Buttons)            │
├─────────────────────────────────────────────────────────┤
│  DANH SÁCH NHÂN VIÊN                 (List Header)     │
├─────────────────────────────────────────────────────────┤
│ ┌───────────────────────────────────────────────────┐  │
│ │ STT │ Tên │ Điện Thoại │ Vị Trí │ Lương │ Ảnh   │  │
│ ├─────┼─────┼───────────┼──────┼──────┼─────┤  │
│ │ ... │ ... │    ...    │ ...  │ ...  │ ... │  │
│ └───────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────┘
```

## 📝 Xử Lý Lỗi

- **Validation**: Kiểm tra dữ liệu bắt buộc trước khi lưu
- **Xác nhận xóa**: Yêu cầu xác nhận trước khi xóa dữ liệu
- **Thông báo lỗi**: Hiển thị chi tiết lỗi khi có vấn đề

## 🔧 Triển Khai Kỹ Thuật

### Dữ Liệu
- Sử dụng `QuanLyNhaHangDataSet` để quản lý dữ liệu
- `EmployeeTableAdapter` để giao tiếp với database
- `BindingSource` để kết nối dữ liệu với UI

### Controls
- **TableLayoutPanel**: Bố cục linh hoạt
- **DataGridView**: Hiển thị danh sách
- **TextBox**: Nhập liệu
- **Button**: Thực hiện thao tác
- **ToolStrip**: Chọn ảnh

## 🚀 Cách Sử Dụng

1. Mở **Admin Panel**
2. Chuyển sang tab **"Nhân Viên"**
3. Thêm nhân viên mới hoặc quản lý nhân viên hiện có

## 📌 Lưu Ý

- Tất cả dữ liệu được lưu trực tiếp vào database SQL Server
- Ảnh được lưu dưới dạng đường dẫn file
- Form được thiết kế để dễ dàng mở rộng thêm chức năng trong tương lai
