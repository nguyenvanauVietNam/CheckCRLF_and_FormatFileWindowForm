using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CheckFormatFile
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            treeView_Seletect.AfterSelect += TreeView1_AfterSelect;
            //ghi log file
            string logFilePath = @"AppsLog.txt";
            l_logger = new Logger(logFilePath);
            l_logger.Log(@"Start log");

            //hiển thị cây thư mục
            l_txtSelectFolder.Text = @"D:\\";

            ShowTreeView(l_txtSelectFolder.Text, treeView_Seletect.Nodes);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ShowTreeView(string duongDan, TreeNodeCollection nodes)
        {
            // Tạo một TreeNode cho thư mục hiện tại
            TreeNode currentNode = new TreeNode(Path.GetFileName(duongDan));
            currentNode.Tag = duongDan; // Lưu trữ đường dẫn trong Tag

            // Thêm nút vào TreeView
            nodes.Add(currentNode);

            try
            {
                // Lấy danh sách thư mục con
                string[] thuMucCon = Directory.GetDirectories(duongDan);

                // Duyệt qua từng thư mục con và gọi đệ quy
                foreach (string thuMuc in thuMucCon)
                {
                    ShowTreeView(thuMuc, currentNode.Nodes);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Xử lý nếu không có quyền truy cập vào một số thư mục
                currentNode.Nodes.Add("Không có quyền truy cập");
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác nếu cần
                currentNode.Nodes.Add("Lỗi: " + ex.Message);
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Lấy đường dẫn từ Tag của TreeNode đã chọn
            string duongDan = e.Node.Tag as string;

            // Hiển thị đường dẫn trong TextBox
            if (duongDan != null)
            {
                l_txtSelectFolder.Text = duongDan;
            }
        }


        private void textBoxSelete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    ShowTreeView(l_txtSelectFolder.Text, treeView_Seletect.Nodes);
                    e.Handled = true; // Ngăn chặn ký tự Enter xuất hiện trong TextBox
                }catch(Exception ex)
                {
                    l_logger.Log(ex.Message.ToString());
                }

            }
        }

        private  void textBoxSelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Xử lý khi Enter được nhấn trong TextBox
                // Gọi hàm hoặc thực hiện các công việc cần thiết ở đây
                try
                {
                    ShowTreeView(l_txtSelectFolder.Text, treeView_Seletect.Nodes);
                    e.SuppressKeyPress = true; // Ngăn chặn ký tự Enter xuất hiện trong TextBox
                }
                catch (Exception ex)
                {
                    l_logger.Log(ex.Message.ToString());
                }
              
            }
        }

        private async void btn_checkCRLF_Click(object sender, EventArgs e)
        {
            // Sử dụng Task.Run để chạy kiểm tra trong một thread nền
            await Task.Run(() => CheckCRLFInFiles(l_txtSelectFolder.Text));
        }
        private void CheckCRLFInFiles(string folderPath)
        {
            try
            {
                // Đặt giá trị tối đa của ProgressBar
                SetProgressBarMaximum(Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories).Length);

                // Đặt giá trị bước tăng của ProgressBar
                SetProgressBarStep(1);

                // Duyệt qua tất cả các file trong thư mục và thư mục con
                foreach (string filePath in Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories))
                {
                    // Kiểm tra dòng mới trong file
                    bool containsCRLF = File.ReadAllText(filePath).Contains("\r\n");

                    // Hiển thị kết quả
                    if (containsCRLF)
                    {
                        AddItemToListBox($"File: {filePath} contains CRLF");
                    }
                    else
                    {
                        AddItemToListBox($"File: {filePath} does not contain CRLF \r\n");

                        // Nếu file không chứa CRLF, thêm đường dẫn vào TextBox
                        //AppendTextToTextBox(textBoxFilesWithoutCRLF, filePath + Environment.NewLine);
                    }

                    // Tăng giá trị của ProgressBar
                    IncrementProgressBar();
                }

                // Đặt giá trị về 0 sau khi kiểm tra hoàn thành
                SetProgressBarValue(0);
            }
            catch (Exception ex)
            {
                l_logger.Log($"Error: {ex.Message}");
            }
        }

        private void SetProgressBarMaximum(int maximum)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() => progressBar1.Maximum = maximum));
            }
            else
            {
                progressBar1.Maximum = maximum;
            }
        }

        private void SetProgressBarStep(int step)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() => progressBar1.Step = step));
            }
            else
            {
                progressBar1.Step = step;
            }
        }

        private void IncrementProgressBar()
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() => progressBar1.PerformStep()));
            }
            else
            {
                progressBar1.PerformStep();
            }
        }

        private void SetProgressBarValue(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() => progressBar1.Value = value));
            }
            else
            {
                progressBar1.Value = value;
            }
        }

        private void AddItemToListBox(string item)
        {
            if (txt_Result.InvokeRequired)
            {
                txt_Result.Invoke(new Action(() => txt_Result.Text += item));
            }
            else
            {
                txt_Result.Text += item;
            }
        }
    }
}
