# Hướng dẫn sử dụng Form Quản Lý Nhân Viên

## Chức năng đã triển khai:

### 1. **Thêm nhân viên mới (Thêm)**
- Nhập thông tin vào các ô:
  - **Tên nhân viên**: Bắt buộc
  - **Số điện thoại**: Bắt buộc
  - **Vị trí**: Bắt buộc
  - **Lương**: Bắt buộc
  - **Ảnh đại diện**: Chọn bằng nút camera (không bắt buộc)
- Nhấn nút **"Thêm"** để lưu vào database
- Dữ liệu sẽ tự động hiển thị ở DataGridView

### 2. **Xem thông tin nhân viên**
- Nhấn vào bất kỳ dòng nào trong DataGridView
- Thông tin của nhân viên sẽ hiển thị trong các ô nhập liệu ở trên

### 3. **Sửa thông tin nhân viên**
- Chọn nhân viên từ DataGridView
- Sửa thông tin trong các ô nhập liệu
- (Tùy chọn) Chọn ảnh mới bằng nút camera
- Nhấn nút **"Sửa"** để cập nhật vào database
- DataGridView sẽ tự động cập nhật

### 4. **Xóa nhân viên**
- Chọn nhân viên từ DataGridView
- Nhấn nút **"Xóa"**
- Xác nhận xóa trong hộp thoại
- Nhân viên sẽ bị xóa từ database và DataGridView

### 5. **Chọn ảnh đại diện**
- Nhấn nút **camera** (ảnh icon) trong phần "Ảnh đại diện"
- Chọn file ảnh từ máy tính (.jpg, .png, .bmp)
- Đường dẫn ảnh sẽ được lưu cùng với thông tin nhân viên

### 6. **Báo cáo & Thoát**
- Nút **"Báo cáo"**: Sẵn sàng cho chức năng xuất báo cáo (cần triển khai thêm)
- Nút **"Thoát"**: Đóng form

## Tính năng đã cải thiện:

✅ **Form co giãn linh hoạt**: Khi kéo hoặc thay đổi kích thước cửa sổ, các thành phần tự động co giãn
✅ **DataGridView tự động cập nhật**: Sau mỗi thao tác thêm/sửa/xóa
✅ **Validation**: Kiểm tra dữ liệu bắt buộc trước khi lưu
✅ **Xác nhận xóa**: Yêu cầu xác nhận trước khi xóa dữ liệu
✅ **Xử lý lỗi**: Hiển thị thông báo lỗi chi tiết khi có vấn đề

## Lưu ý:

- Tất cả các thay đổi được lưu trực tiếp vào database qua SQL Server
- Ảnh được lưu dưới dạng đường dẫn file
- Form được thiết kế để dễ dàng mở rộng thêm chức năng trong tương lai
