# Nhóm 21 - V-CORE Messenger 🚀

Ứng dụng truyền thông nội bộ dựa trên kiến trúc **TCP Socket bất đồng bộ** (Asynchronous TCP Socket).

## 📝 Giới thiệu
V-CORE Messenger là một giải pháp chat desktop standalone, tập trung vào việc tối ưu hóa hiệu suất truyền tin trong mạng nội bộ (LAN). Dự án sử dụng mô hình Client-Server thuần túy với giao thức nhị phân tự định nghĩa (Custom Binary Protocol) để đảm bảo tốc độ và tính bảo mật ở mức thấp.

## ✨ Tính năng chính
- 💬 **Chat văn bản thời gian thực**: Hỗ trợ chat cá nhân và nhóm với độ trễ tối thiểu.
- 📦 **Giao thức nhị phân (Binary Protocol)**: Header 8-byte tối ưu hóa băng thông.
- 📂 **Truyền file theo khối (Chunking)**: Hỗ trợ gửi file lớn bằng cách chia nhỏ thành các khối 4KB.
- ⚡ **Xử lý bất đồng bộ**: Server sử dụng mô hình Non-blocking I/O để xử lý hàng ngàn kết nối đồng thời.
- 🛡️ **Kiểm tra dữ liệu**: Tích hợp Checksum bảo vệ tính toàn vẹn của gói tin.
- 📜 **Audit Log**: Ghi lại toàn bộ lịch sử kết nối và hoạt động hệ thống.

## 🛠️ Công nghệ sử dụng
- **Ngôn ngữ**: C# / .NET
- **Networking**: System.Net.Sockets (TcpListener, TcpClient)
- **Kiến trúc**: Asynchronous Pattern (Async/Await)
- **Protocol**: Custom Binary Data Framing

## 📂 Cấu trúc thư mục
- `VCore.Common`: Thư viện dùng chung (Models, Protocol, Utils).
- `VCore.Server`: Source code của máy chủ điều phối tin nhắn.
- `VCore.Client`: Source code của máy khách (Desktop Application).

---
*© 2026 - Nhóm 21 - Đồ án Lập trình mạng*
