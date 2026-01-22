# 📈 NHOM21 FINANCIAL TERMINAL – HỆ THỐNG GIAO DỊCH TÀI CHÍNH

Hệ thống mô phỏng sàn giao dịch và thiết bị đầu cuối tài chính thời gian thực (Real-time Financial Terminal) dựa trên kiến trúc **TCP Socket** bất đồng bộ. Dự án bao gồm một Server trung tâm phát dữ liệu thị trường và Client "Premium" để theo dõi và phân tích.

![UI Preview](https://via.placeholder.com/800x450.png?text=Financial+Terminal+Preview)

## 🌟 Tính Năng Nổi Bật

### 1. Kiến Trúc Client-Server Mạnh Mẽ
- **TCP Socket Asynchronous**: Đảm bảo hiệu năng cao, độ trễ thấp khi truyền tải dữ liệu giá theo thời gian thực.
- **Multi-Client Support**: Server có khả năng phục vụ nhiều Client cùng lúc mà không bị tắc nghẽn.
- **Protocol Tùy Biến**: Giao thức đóng gói dữ liệu riêng giúp tối ưu hóa băng thông.

### 2. Giao Diện "Premium" (Modern UI)
Client được thiết kế lại hoàn toàn với phong cách hiện đại, chuyên nghiệp:
- **Gradient Header**: Thanh tiêu đề với hiệu ứng màu chuyển tiếp sang trọng (Glass-morphism).
- **Dark/Light Mode**: Tùy chọn chế độ Sáng/Tối phù hợp với môi trường làm việc.
- **Sparklines**: Biểu đồ mini tích hợp ngay trong bảng giá để theo dõi xu hướng nhanh.
- **Visual Cues**: Tự động đổi màu (Xanh/Đỏ) và hiệu ứng flash khi giá biến động.
- **Borderless Window**: Cửa sổ không viền, bo góc mềm mại, hỗ trợ kéo thả tùy chỉnh.
- **Responsive Animations**: Hiệu ứng mượt mà khi tương tác (hover, click, update dữ liệu).

## �️ Công Nghệ Sử Dụng
- **Ngôn Ngữ**: C# (.NET 6.0/8.0)
- **Framework**: Windows Forms (WinForms) với GDI+ Custom Drawing.
- **Networking**: `System.Net.Sockets`
- **Mô hình**: Asynchronous TCP/IP

## 🚀 Hướng Dẫn Cài Đặt & Chạy

### Yêu Cầu
- .NET SDK (6.0 hoặc mới hơn).
- Visual Studio 2022 hoặc VS Code.

### Các Bước Thực Hiện
1. **Clone Repository**
   ```bash
   git clone https://github.com/hieupnm805208-glitch/Nhom21--FINANCIAL-TERMINAL.git
   cd "Nhom21--FINANCIAL-TERMINAL"
   ```

2. **Chạy Server** (Sàn giao dịch)
   - Mở terminal tại thư mục Server.
   - Chạy lệnh: `dotnet run`
   - Server sẽ khởi động tại địa chỉ `127.0.0.1:8888`.

3. **Chạy Client** (Terminal người dùng)
   - Mở terminal tại thư mục Client.
   - Chạy lệnh: `dotnet run`
   - Nhập IP và Port (mặc định đã điền sẵn) và nhấn **"Kết nối"**.

## 👥 Thành Viên Nhóm 21
- **[Tên Thành Viên]** - Trưởng nhóm / Backend
- **[Tên Thành Viên]** - Frontend / UI Design
- **[Tên Thành Viên]** - Tester / Documentation

---
*Dự án môn học Lập trình ứng dụng mạng - Năm học 2024-2025*
