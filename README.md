📙Bookstore Management System - WinForms & SQL Server  
Đồ án môn Lập trình Cơ sở Dữ liệu - Trường ĐH Mở TP.HCM  
Nhóm sinh viên: Hồ Hoàn Hảo, Lê Thị Ngọc Hân, Nguyễn Lê Huệ Tiên

✨ Giới thiệu
Hệ thống quản lý cửa hàng bán sách hỗ trợ các hoạt động:
- Quản lý sách, kho, đơn hàng, thanh toán, nhân viên, khách hàng
- Hỗ trợ giao diện dễ dùng cho các vai trò: Khách hàng, Nhân viên, Quản trị viên
- Triển khai theo mô hình 3 lớp: Presentation - BLL - DAL

⚡ Công nghệ - Kiến trúc
Thành phần          Công nghệ
Ngôn ngữ          C# WinForms
Database          Microsoft SQL Server
Data Access       ADO.NET
Biểu đồ           Chart Control
Giao diện         WinForms + Visual Studio

📊 Chức năng chính
Truy cập theo vai trò:
- Khách hàng: Đăng ký/Đăng nhập, xem sách, thêm vào giỏ, thanh toán, xem đơn hàng
- Nhân viên: Nhập kho, quản lý đơn hàng, quản lý sách, nhà cung cấp
- Admin: Quản lý nhân viên, xem thống kê, thiết lập quy định nhập kho

💡 Thông tin của sách:
- Tên, tác giả, giá bán, trạng thái còn/tồn kho, hình ảnh bìa

📅 Kịch bản sử dụng

Kịch bản 1: Khách hàng đặt sách online
- Đăng nhập/Đăng ký
- Tìm kiếm sách
- Thêm vào giỏ
- Thanh toán (QR code)
- Xem lịch sử đơn hàng

Kịch bản 2: Nhân viên nhập kho
- Đăng nhập (vai trò nhân viên)
- Nhập sách mới hoặc cập nhật tồn kho
- Xuất phiếu nhập kho
- Hiển thị lên giao diện người dùng

Kịch bản 3: Admin xem thống kê
- Đăng nhập bằng tài khoản admin
- Xem thống kê:
  + Doanh thu theo tháng (biểu đồ đường)
  + Doanh thu theo thể loại (biểu đồ cột)
  + Top 5 sách bán chạy (biểu đồ tròn)
  + Số đơn hàng trong năm

💮 Thiết kế CSDL
Gồm các bảng chính:
- Book, BookCategory, Stock, Orders, OrderDetails
- Users, Customers, Suppliers
- Bill_Generate, Payments, Rules
- Dữ liệu quan hệ với nhau bằng khóa ngoại, thiết kế mở rộng và linh hoạt

🏆 Kết luận
Đề tài giúp nhóm rèn luyện về quy trình phát triển phần mềm từ phân tích, thiết kế, xây dựng đến triển khai ứng dụng.Tuy còn một số hạn chế về tính năng web/mobile, nhưng hệ thống đã đáp ứng tốt cho bài toán thực tế tại cửa hàng sách quy mô vừa và nhỏ.

PDF full chi tiết báo cáo (nếu cần)
[Báo cáo.pdf](https://github.com/user-attachments/files/20213180/Bao.cao.pdf)
