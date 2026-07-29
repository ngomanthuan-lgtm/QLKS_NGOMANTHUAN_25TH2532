using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace QLKS_NGOMANTHUAN_25TH2532.Services
{
    public class EmailService
    {
        public static async Task SendBookingEmailAsync(string targetEmail, string customerName, string roomNumber, string fromDate, string toDate, string price)
        {
            var message = new MimeMessage();
            // 1. Cấu hình thông tin người gửi (Hệ thống khách sạn)
            message.From.Add(new MailboxAddress("ROYAL HOTEL SYSTEM", "thuan.nm.cc25cth@ntu.edu.vn"));
            // 2. Cấu hình người nhận (Email khách hàng)
            message.To.Add(new MailboxAddress(customerName, targetEmail));
            // 3. Tiêu đề thư
            message.Subject = $"[ROYAL HOTEL] - XÁC NHẬN ĐẶT PHÒNG THÀNH CÔNG #{roomNumber}";

            // 4. Thiết kế giao diện nội dung Email bằng HTML sang trọng
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; border: 1px solid #d4af37; border-radius: 10px; padding: 20px; background-color: #fcfbf7;'>
                    <h2 style='color: #d4af37; text-align: center; text-transform: uppercase;'>Xác Nhận Đặt Phòng Trực Tuyến</h2>
                    <p>Xin chào <strong>{customerName}</strong>,</p>
                    <p>Hệ thống Royal ERP ghi nhận bạn đã đặt phòng trực tuyến thành công với thông tin chi tiết như sau:</p>
                    <table style='width: 100%; border-collapse: collapse; margin: 20px 0;'>
                        <tr style='background-color: #d4af37; color: white;'>
                            <th style='padding: 10px; text-align: left;'>Danh Mục</th>
                            <th style='padding: 10px; text-align: left;'>Thông Tin Phiếu</th>
                        </tr>
                        <tr>
                            <td style='padding: 10px; border-bottom: 1px solid #ddd;'><strong>Mã Số Phòng:</strong></td>
                            <td style='padding: 10px; border-bottom: 1px solid #ddd; color: #dc3545; font-weight: bold;'>Phòng {roomNumber}</td>
                        </tr>
                        <tr>
                            <td style='padding: 10px; border-bottom: 1px solid #ddd;'><strong>Ngày Nhận Phòng:</strong></td>
                            <td style='padding: 10px; border-bottom: 1px solid #ddd;'>{fromDate}</td>
                        </tr>
                        <tr>
                            <td style='padding: 10px; border-bottom: 1px solid #ddd;'><strong>Ngày Trả Phòng:</strong></td>
                            <td style='padding: 10px; border-bottom: 1px solid #ddd;'>{toDate}</td>
                        </tr>
                        <tr>
                            <td style='padding: 10px; border-bottom: 1px solid #ddd;'><strong>Đơn Giá/Đêm:</strong></td>
                            <td style='padding: 10px; border-bottom: 1px solid #ddd; color: #28a745; font-weight: bold;'>{price} VNĐ</td>
                        </tr>
                    </table>
                    <p style='font-style: italic; color: #666;'>Cảm ơn bạn đã lựa chọn dịch vụ của Royal Hotel. Vui lòng xuất trình email này tại quầy lễ tân khi làm thủ tục Check-in nhận phòng.</p>
                    <hr style='border: 0; border-top: 1px solid #d4af37;' />
                    <p style='text-align: center; font-size: 0.8rem; color: #999;'>Hệ thống quản lý khách sạn - MSSV: 25TH2532 - Ngô Mẫn Thuận</p>
                </div>";

            message.Body = bodyBuilder.ToMessageBody();

            // 5. Kết nối đến Server SMTP Google để phát thư đi
            using (var client = new SmtpClient())
            {
                // Kết nối qua cổng bảo mật 587
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                // QUAN TRỌNG: Thay bằng Email của bạn và "Mật khẩu ứng dụng" (App Password) sinh từ Google Account
                await client.AuthenticateAsync("thuan.nm.cc25cth@ntu.edu.vn", "ugdbhzmkuhqtcusm");

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
