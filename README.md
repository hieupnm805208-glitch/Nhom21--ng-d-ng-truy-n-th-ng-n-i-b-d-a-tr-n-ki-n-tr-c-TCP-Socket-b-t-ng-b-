# 🎙️ NHOM21 AUDIO CONNECTOR – ỨNG DỤNG TRUYỀN THÔNG GIỌNG NÓI

Hệ thống truyền thông giọng nói nội bộ (Voice over IP) thời gian thực dựa trên kiến trúc **TCP Socket** bất đồng bộ. Dự án bao gồm một Server trung tâm xử lý tín hiệu/kết nối và các Client cho phép người dùng thực hiện cuộc gọi thoại trực tiếp với chất lượng âm thanh ổn định và giao diện hiện đại.

![UI Preview](https://via.placeholder.com/800x450.png?text=Audio+Connector+Preview)

## 🌟 Tính Năng Nổi Bật

### 1. Truyền Thông Thời Gian Thực (Real-time Communication)
- **Voice Call**: Truyền tải âm thanh giọng nói hai chiều giữa các client thông qua Server.
- **Low Latency**: Tối ưu hóa gói tin TCP để giảm độ trễ, đảm bảo cuộc hội thoại tự nhiên.
- **NAudio Integration**: Sử dụng thư viện NAudio để thu âm (Microphone) và phát lại âm thanh (Speaker) với chất lượng cao.

### 2. Giao Diện Hiện Đại & Trực Quan
- **Modern Dark UI**: Giao diện tối màu, giảm mỏi mắt, mang phong cách ứng dụng chuyên nghiệp.
- **Audio Visualizer**: Biểu đồ sóng âm (Waveform) hiển thị thời gian thực, phản hồi theo cường độ âm thanh đầu vào/đầu ra.
- **Connection Status**: Trạng thái kết nối (Online/Offline) và Logs chi tiết giúp người dùng dễ dàng theo dõi.

## 🛠️ Công Nghệ Sử Dụng
- **Ngôn Ngữ**: C# (.NET 10.0)
- **Framework**: Windows Forms (WinForms)
- **Thư viện âm thanh**: [NAudio](https://github.com/naudio/NAudio)
- **Giao thức mạng**: TCP/IP Sockets (Asynchronous)

## 🚀 Hướng Dẫn Cài Đặt & Chạy

### Yêu Cầu
- .NET SDK (10.0 hoặc tương thích).
- Visual Studio 2022 hoặc VS Code.
- Microphone và Loa/Tai nghe.

### Các Bước Thực Hiện

1. **Clone Repository**
   ```bash
   git clone https://github.com/hieupnm805208-glitch/Nhom21-Laptrinhungdung-Audio.git
   cd "Nhom21-Laptrinhungdung-Audio"
   ```

2. **Chạy Server** (Bộ chuyển tiếp tín hiệu)
   - Mở terminal, di chuyển vào thư mục Server:
     ```bash
     cd Nhom21.AudioConnector.Server
     ```
   - Chạy lệnh:
     ```bash
     dotnet run
     ```
   - Server sẽ lắng nghe tại cổng mặc định `11000`.

3. **Chạy Client** (Người dùng cuối)
   - Mở một (hoặc nhiều) terminal khác, di chuyển vào thư mục Client:
     ```bash
     cd Nhom21.AudioConnector.Client
     ```
   - Chạy lệnh:
     ```bash
     dotnet run
     ```
   - Nhập **Server IP** (thường là `127.0.0.1` nếu chạy local) và nhấn **"Connect"**.
   - Nhấn **"Start Call"** để bắt đầu gửi/nhận âm thanh.

## 👥 Thành Viên Nhóm 21
- **[Tên Thành Viên]** - Trưởng nhóm / Backend
- **[Tên Thành Viên]** - Frontend / UI Design
- **[Tên Thành Viên]** - Tester / Documentation

---
*Dự án môn học Lập trình ứng dụng mạng - Năm học 2024-2025*
