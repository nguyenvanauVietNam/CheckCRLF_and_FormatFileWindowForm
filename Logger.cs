using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckFormatFile
{
    public class Logger
    {
        private string filePath;

        public Logger(string filePath)
        {
            this.filePath = filePath;
        }

        public void Log(string message)
        {
            try
            {
                // Mở tập tin để ghi, nếu tập tin không tồn tại sẽ tạo mới
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    // Ghi thông điệp vào tập tin
                    sw.WriteLine($"{DateTime.Now} - {message}");
                }
            }
            catch (Exception ex)
            {
                // Xử lý nếu có lỗi khi ghi log
                Console.WriteLine($"Lỗi khi ghi log: {ex.Message}");
            }
        }
    }
}
