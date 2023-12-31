﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CheckFormatFile
{
    public partial class MainForm : Form
    {

        public MainForm()
        {

            InitializeComponent();
            treeView_Seletect.AfterSelect += TreeView1_AfterSelect; // Make sure to add this line
            // Initialize log directory
            string logFolderPath = Path.Combine(Application.StartupPath, "ApplicationLog");
            EnsureLogDirectoryExists(logFolderPath);
            toolTip = new System.Windows.Forms.ToolTip();
            // Create log file paths
            string timestampSuffix = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string logFilePath = $"ApplicationLog/AppsLog_{timestampSuffix}.txt";
            string logFilePathCRLF = $"ApplicationLog/AppsLogCRLF_{timestampSuffix}.txt";
            string logFilePath_NOT_CRLF = $"ApplicationLog/AppsLogNOTCRLF_{timestampSuffix}.txt";
            string logFilePath_FormatFile = $"ApplicationLog/AppsLogFormatFile_{timestampSuffix}.txt";
            string logFilePath_NotUTF8 = $"ApplicationLog/AppsLogFormatNotFile_{timestampSuffix}.txt";

            // Create logger instances
            l_logger_Fuction = new Logger(logFilePath);
            l_logger_CRLF = new Logger(logFilePathCRLF);
            l_logger_Not_CRLF = new Logger(logFilePath_NOT_CRLF);
            l_logger_UTF8 = new Logger(logFilePath_FormatFile);
            l_logger_Not_UTF8 = new Logger(logFilePath_NotUTF8);

            SetLangApplication();

            //cài đặt tooltips
            toolTip = new System.Windows.Forms.ToolTip();

            //Cài đặt Combobox
            comboBox1.SelectedIndex = 1;
            // Đặt kiểu DropDown cho ComboBox thành DropDownList
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // Initialize tree view
            l_txtSelectFolder.Text = @"D:\";
            ShowTreeView(l_txtSelectFolder.Text, treeView_Seletect.Nodes);
        }

        private void LogStartApplication(string appVersion,string Language)
        {

            l_logger_Fuction.Log($"Start application version {appVersion} set default language: {Language}");
            l_logger_CRLF.Log($"Start application version {appVersion}");
            l_logger_Not_CRLF.Log($"Start application version {appVersion}");
            l_logger_UTF8.Log($"Start application version {appVersion}");
            l_logger_Not_UTF8.Log($"Start application version {appVersion}");
        }
        private void SetLangApplication()
        {

            // Thiết lập ngôn ngữ cho ứng dụng
            string l_Lang_App =  GetDefaultLanguage();
            CultureInfo cultureInfo = new CultureInfo(l_Lang_App);
            // Đổi ngôn ngữ tùy thuộc vào nhu cầu của bạn
           
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            // loại bỏ vấn đề nhấn vào combobox
            combobox_Lang.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox_Lang.Items.Clear();
            // Log application start
            string appVersion = Application.ProductVersion;
            string resourcefile = "";
            if (l_Lang_App == "ja-JP")
            {
                //Tiếng Nhật
                combobox_Lang.Items.Add("Japanese/日本語");
                combobox_Lang.Items.Add("English/英語");
                combobox_Lang.SelectedIndex = 0;
                LogStartApplication(appVersion, "Japanese/日本語");
                resourcefile = $"CheckFormatFile.Resources.Resource_MultiLanguage_JPN";
            }
            else if(l_Lang_App =="en-US")
            {
                //Tiếng Anh
                combobox_Lang.Items.Add("English/英語");
                combobox_Lang.Items.Add("Japanese/日本語");
                combobox_Lang.SelectedIndex = 0;
                LogStartApplication(appVersion, "English/英語");
                resourcefile = $"CheckFormatFile.Resources.Resource_MultiLanguage_ENG";
            }
            else { }
            SetLanguageForControlApp(resourcefile);//set lang
        }

        private void SetLanguageForControlApp(string resourcefile)
        {
            try
            {
                // Tạo một đối tượng ResourceManager với đường dẫn tệp .resx
                ResourceManager resourceManager = new ResourceManager(resourcefile, typeof(Program).Assembly);
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentUICulture;

                // Đọc giá trị từ tệp .resx và set giá trị cho từng con trol trong windows
                //string value = resourceManager.GetString("Lang_value", cultureInfo);
                stactic_label_Browser.Text = resourceManager.GetString("Label_Browser", cultureInfo);
                groupBox2.Text = resourceManager.GetString("Group_CheckCRLF", cultureInfo);
                groupBox1.Text = resourceManager.GetString("Group_CheckEnCoding", cultureInfo);
                label2.Text = resourceManager.GetString("label_Extendstion", cultureInfo);
                stactic_label_Version.Text = resourceManager.GetString("Version_label", cultureInfo);
                l_label_version.Text = Application.ProductVersion;//application Version
                stactic_label_Lang.Text = resourceManager.GetString("Lang_label", cultureInfo);
                //Button
                l_btn_CheckUpdate.Text = resourceManager.GetString("Button_CheckUpdate", cultureInfo);
                btn_checkCRLF.Text = resourceManager.GetString("Button_check_CRLF", cultureInfo);
                btn_CRLF_OpenFile.Text = resourceManager.GetString("Button_OpenFile_CheckCRLF", cultureInfo);
                btn_OpenLog.Text = resourceManager.GetString("Button_Open_Log", cultureInfo);
                btn_FormatFile.Text = resourceManager.GetString("Button_Check_Encoding", cultureInfo);
                btn_OpenFile.Text = resourceManager.GetString("Button_OpenFile_Check_Encoding", cultureInfo);
                btn_Exit.Text = resourceManager.GetString("Button_Exit", cultureInfo);

                //Tooltips
                toolTip.RemoveAll(); //remove truoc khi set gia tri

                toolTip.SetToolTip(btn_checkCRLF, resourceManager.GetString("Tooltips_buttoncheck_CRLF", cultureInfo));
                toolTip.SetToolTip(btn_CRLF_OpenFile, resourceManager.GetString("Tooltips_buttonOpenFile_CheckCRLF", cultureInfo));
                toolTip.SetToolTip(btn_OpenLog, resourceManager.GetString("Tooltips_buttonOpen_Log", cultureInfo));


                toolTip.SetToolTip(btn_FormatFile, resourceManager.GetString("Tooltips_buttonCheck_Encoding", cultureInfo));
                toolTip.SetToolTip(btn_OpenFile, resourceManager.GetString("Tooltips_buttonOpenFile_Check_Encoding", cultureInfo));
                toolTip.SetToolTip(btn_Exit, resourceManager.GetString("Tooltips_buttonExit", cultureInfo));

                toolTip.SetToolTip(l_btn_CheckUpdate, resourceManager.GetString("Tooltips_Button_Check_Update", cultureInfo));
                toolTip.SetToolTip(combobox_Lang, resourceManager.GetString("Tooltips_combobox_Lang", cultureInfo));

                //combobox
                toolTip.SetToolTip(comboBox1, resourceManager.GetString("Tooltips_Combobox_Encondig", cultureInfo));
            }
            catch (Exception ex)
            {
                //TODO code    
            }
        }


        // Đọc giá trị của khóa từ app.config
        private string GetDefaultLanguage()
        {
            string defaultLanguage = ConfigurationManager.AppSettings["DefaultLanguage"];
            return defaultLanguage;
        }
        // ghi giá trị của khóa từ app.config
        private void SetDefaultLanguage(string key, string value)
        {
            try
            {
                // Load cấu hình từ file app.config
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Kiểm tra xem khóa có tồn tại không
                if (configuration.AppSettings.Settings[key] != null)
                {
                    // Cập nhật giá trị cho khóa
                    configuration.AppSettings.Settings[key].Value = value;

                    // Lưu cấu hình mới
                    configuration.Save(ConfigurationSaveMode.Modified);

                    // Force một refresh để áp dụng các thay đổi
                    ConfigurationManager.RefreshSection("appSettings");
                }
                else
                {
                    // Nếu khóa không tồn tại, bạn có thể tạo mới nếu cần thiết
                    configuration.AppSettings.Settings.Add(key, value);
                    configuration.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
            catch (ConfigurationErrorsException)
            {
               //Todo
            }
        
    }

        private void ShowTreeView(string folderPath, TreeNodeCollection nodes)
        {
            try
            {
                TreeNode currentNode = new TreeNode(Path.GetFileName(folderPath))
                {
                    Tag = folderPath
                };
                nodes.Add(currentNode);

                foreach (string subFolder in Directory.GetDirectories(folderPath))
                {
                    ShowTreeView(subFolder, currentNode.Nodes);
                }
            }
            catch (UnauthorizedAccessException)
            {
                nodes.Add("Not have access");
            }
            catch (Exception ex)
            {
                nodes.Add($"Errors: {ex.Message}");
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedPath = e.Node.Tag as string;
            l_txtSelectFolder.Text = selectedPath ?? "";
        }

        private void textBoxSelete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                UpdateTreeView();
            }
        }

        private void textBoxSelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                UpdateTreeView();
            }
        }

        private void UpdateTreeView()
        {
            try
            {
                ShowTreeView(l_txtSelectFolder.Text, treeView_Seletect.Nodes);
            }
            catch (Exception ex)
            {
                l_logger_Fuction.Log($"exception error: {ex.Message}");
            }
        }

        private void btn_checkCRLF_Click(object sender, EventArgs e)
        {
            CheckCRLFInFolder(l_txtSelectFolder.Text);
            l_logger_Fuction.Log($"CRLF check completed\r\n");
            l_logger_Not_CRLF.Log($" check completed\r\n");
            l_logger_CRLF.Log($" check completed\r\n");

        }

        private void CheckCRLFInFolder(string folderPath)
        { 
            try
            {
                // Get all files in the current folder and its subfolders with specified extensions
                string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

                int totalFiles = files.Length;
                l_logger_Fuction.Log($"Start check CRLF with Total File: {totalFiles.ToString()}");
                //Xóa Text trước đó
                txt_Result.Text = string.Empty;
               txt_Result.Text = $"Start check folder: {folderPath}\r\n";
                txt_Result.Text += $"Total Files: {totalFiles.ToString()}\r\n";

                int l_SumFileCRLF = 0;
                int l_SumFileLF = 0;
                SetProgressBarMaximum();

                int percent = 0;

                foreach (string filePath in files)
                {
                    bool containsCRLF = File.ReadAllText(filePath).Contains("\r\n");
                    SetProgressBarValue((percent*100/ totalFiles));

                    if (containsCRLF)
                    {
                        l_logger_CRLF.Log($"File CRLF:  {filePath} contains CRLF");
                        l_SumFileCRLF++;
                    }
                    else
                    {
                        try
                        {
                            // Đọc từng dòng và xử lý
                            ProcessFile(filePath);
                            l_logger_CRLF.Log($"Fixed file: {filePath} by adding CRLF");
                        }
                        catch (Exception ex)
                        {
                            l_logger_CRLF.Log($"Lỗi: {ex.Message}");
                        }
                        l_SumFileLF++;
                    }

                    IncrementProgressBar();
                    percent++;
                }

                txt_Result.Text += $"Files CRLF: {l_SumFileCRLF.ToString()}\r\n";
                txt_Result.Text += $"Files NOT CRLF: {l_SumFileLF.ToString()}\r\n";
                //đặt lại về ban đầu
                l_SumFileCRLF = 0;
                l_SumFileLF = 0;
                SetProgressBarValue(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"Please choose folder small!","Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
                l_logger_Fuction.Log($"Error: {ex.Message}");
            }
        }

        private void SetProgressBarMaximum()
        {
              progressBar1.Maximum = 100;
        }

        private void IncrementProgressBar()
        {
                progressBar1.PerformStep();
        }

        private void SetProgressBarValue(int value)
        {
                progressBar1.Value = value;
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            l_logger_Fuction.Log($"Application click button Exit");
            Application.Exit();
        }

        private void EnsureLogDirectoryExists(string logFolderPath)
        {
            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }
        }
        private void ProcessFile(string filePath)
        {
            // Tạo một tệp tạm để lưu trữ kết quả
            string tempFilePath = Path.GetTempFileName();

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var writer = new StreamWriter(tempFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Chuyển đổi dòng và ghi vào tệp tạm
                        string convertedLine = ConvertToCRLF(line);
                        writer.WriteLine(convertedLine);
                    }
                }

                // Sau khi xử lý hết file, thay thế file gốc bằng file tạm
                File.Copy(tempFilePath, filePath, true);
            }
            finally
            {
                // Xóa tệp tạm sau khi sử dụng
                File.Delete(tempFilePath);
            }
        }
        static string ConvertToCRLF(string input)
        {
            // Dùng StringBuilder để tối ưu hiệu suất khi thực hiện các thao tác chuỗi
            StringBuilder result = new StringBuilder();

            // Duyệt qua từng ký tự trong chuỗi đầu vào
            for (int i = 0; i < input.Length; i++)
            {
                // Nếu là ký tự xuống dòng không phải CRLF, thì thêm CRLF vào kết quả
                if (input[i] == '\n' && (i == 0 || input[i - 1] != '\r'))
                {
                    result.Append("\r\n");
                }
                // Ngược lại, thêm ký tự vào kết quả
                else
                {
                    result.Append(input[i]);
                }
            }

            return result.ToString();
        }


        private void CheckCRLFFile(string filePath)
        {
            SetProgressBarValue(1);
            //Xóa Text trước đó
            txt_Result.Text = string.Empty;
            txt_Result.Text = $"Start check file: {Path.GetFileName(filePath)}\r\n";
            try { 
                bool containsCRLF = File.ReadAllText(filePath).Contains("\r\n");
                if (containsCRLF)
                {
                    l_logger_CRLF.Log($"File CRLF:  {filePath} contains CRLF");
                    txt_Result.Text += $"{Path.GetFileName(filePath)} contains CRLF\n";
                }
                else
                {
                    try
                    {
                        txt_Result.Text += $"{Path.GetFileName(filePath)} not CRLF\r\n";
                        // Đọc từng dòng và xử lý
                        ProcessFile(filePath);
                        l_logger_CRLF.Log($"Fixed file: {filePath} by adding CRLF");
                    }
                    catch (Exception ex)
                    {
                        l_logger_CRLF.Log($"Lỗi: {ex.Message}");
                    }

                }

            }catch(Exception ex)
            { 
                l_logger_Fuction.Log($"Error check CRLF with Exception:{ex.Message}"); 
            }
            SetProgressBarValue(50);
            Thread.Sleep(1000);
            SetProgressBarValue(100);
        }
        private void btn_CRLF_OpenFile_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại mở file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Thiết lập các thuộc tính của hộp thoại mở file
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Select a file to process";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của file đã chọn
                string selectedFilePath = openFileDialog.FileName;
                // Xử lý file đã chọn
                l_logger_Fuction.Log($"Start check CRLF with File: {selectedFilePath}");
                CheckCRLFFile(selectedFilePath);
                l_logger_Fuction.Log($"End check CRLF with File: {selectedFilePath}");
            }
        }

        private void btn_OpenLog_Click(object sender, EventArgs e)
        {

            // Thiết lập tiêu đề cho hộp thoại mở thư mục

            string folderPath = Path.GetDirectoryName(Path.GetFullPath(l_logger_Fuction.GetpathFile()));

            try
            {
                // Sử dụng Process.Start để mở thư mục bằng Explorer
                Process.Start("explorer.exe", folderPath);
            }
            catch (Exception ex)
            {
                l_logger_Fuction.Log($"Lỗi khi mở thư mục: {ex.Message}");
            }
        }

        //Bỏ qua file nếu chứa ký tự đặc biệt
        private bool IsIgnoredFile(string filepath)
        {

            // Kiểm tra đường dẫn file có chứa thư mục đã cài đặt ở app.config không
            string ignoredFoldersSetting = ConfigurationManager.AppSettings["IgnoredFolders"];
            if (!string.IsNullOrEmpty(ignoredFoldersSetting))
            {
                // Chia chuỗi thành mảng các thư mục bằng dấu phẩy
                string[] ignoredFolders = ignoredFoldersSetting.Split(',');

                // Sử dụng mảng ignoredFolders như bạn đã làm trước đó
                foreach (string ignoredFolder in ignoredFolders)
                {
                    if (filepath != null && filepath.Contains(ignoredFolder))
                    {
                        return true;
                    }
                }
            }
            else
            {
                l_logger_Fuction.Log("Không tìm thấy giá trị trong app.config");
            }

            string fileName = Path.GetFileName(filepath);
            // Đọc giá trị của khóa "IgnoredExtensions" từ cấu hình
            string extensionsConfig = ConfigurationManager.AppSettings["IgnoredExtensions"];

            // Phân tách các phần mở rộng thành một mảng
            string[] ignoredExtensions = extensionsConfig?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (ignoredExtensions != null && ignoredExtensions.Length > 0)
            {
                // Kiểm tra có phải là file có phần mở rộng trong danh sách hoặc có chứa ký tự đặc biệt
                bool hasValidExtension = ignoredExtensions.Any(ext =>
                    Path.GetExtension(fileName).Equals(ext, StringComparison.OrdinalIgnoreCase));

                // Kiểm tra có chứa ký tự đặc biệt hay không
                bool containsSpecialCharacter = ContainsSpecialCharacter(fileName);

                // Trả về true nếu là file có phần mở rộng trong danh sách hoặc có chứa ký tự đặc biệt
                return hasValidExtension || containsSpecialCharacter;
            }
            else
            {
                MessageBox.Show(this, "Please check app.config file!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                l_logger_Fuction.Log($"Không tìm thấy phần mở rộng nào trong cấu hình.\r\n");
            }
            // Trả về true nếu là file config rỗng để tránh lỗi đáng tiếc
            return true;
        }
        //Kiểm tra tên file có chứa ký tự đặc biệt
        private bool ContainsSpecialCharacter(string input)
        {
            // Kiểm tra xem chuỗi có chứa ký tự đặc biệt hay không
            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c) && c != '_' && c != '-' && c != '.')
                {
                    return true;
                }
            }

            return false;
        }

        //Check Endcoding files in Folder
        private void CheckEncodingFolder(string folderPath, string targetEncoding)
        {
            try
            {
                // Get all files in the current folder and its subfolders with specified extensions
                string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
                SetProgressBarMaximum();
                int totalFiles = files.Length;
                int percent = 0;
                int currentFile = 0;
                SetProgressBarValue(0);//cài đặt thanh progressbar
                foreach (string filePath in files)
                {
                    currentFile++;
                    string filename = Path.GetFileName(filePath);
                    if (!IsIgnoredFile(filePath))
                    {
                        string currentEncoding = GetFileEncoding(filePath);
                        

                        switch(targetEncoding)
                        {
                            case "UTF8withoutBOM":
                                if (CheckFileEncoding(filePath) == 2)
                                {
                                    //UTF8 
                                }
                                if (CheckFileEncoding(filePath) == -1)
                                {
                                    //Lỗi không xác định
                                }
                                else
                                {
                                    //Không phải UTF8
                                    //đưa nó về UTF8
                                    ConvertFileEncoding(filePath,Encoding.UTF8.ToString());

                                }
                                break;
                            case "UTF8withBOM":
                                //check xem file đã là UTF8-Bom chưa?
                                if(CheckFileEncoding(filePath) == 1)
                                {
                                    //UTF8-BOM
                                }    
                                if(CheckFileEncoding(filePath) == -1)
                                {
                                    //Lỗi không xác định
                                }
                                else 
                                {
                                    //Không phải UTF8-BOM
                                    //đưa nó về UTF8-BOM
                                    ConvertFileEncodingUTF8withBOM(filePath);

                                }
                                break;

                            default:
                                //Check xem file đã đúng định dạng
                                if(currentEncoding != targetEncoding)
                                {
                                    //không  đúng định dạng
                                    //Chuyển nó về định dạng đúng
                                    ConvertFileEncoding(filePath, targetEncoding);

                                } 
                                else
                                {
                                    //Đúng định dạng
                                    
                                }    
                                break;
                        }    
                    }
                    else 
                    {
                        //các file bị bỏ qua
                    }
                    percent = currentFile * 100 / totalFiles;
                    SetProgressBarValue(percent);//cài đặt thanh progressbar
                }

                SetProgressBarValue(0);//reset thanh progressbar sau khi chạy
            }
            catch (Exception ex)
            {
                l_logger_Fuction.Log($"Errors: {ex.Message}");
            }
        }

        private string GetFileEncoding(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath, true))
            {
                reader.Peek(); // Ensure the StreamReader reads the BOM correctly
                return reader.CurrentEncoding.WebName;
            }
        }

        private void ConvertFileEncodingUTF8withBOM(string filePath)
        {
            // Tạo một tệp tạm để lưu trữ kết quả
            string tempFilePath = Path.GetTempFileName();

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var writer = new StreamWriter(tempFilePath, false, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Chuyển đổi dòng và ghi vào tệp tạm
                        string convertedLine = ConvertToCRLF(line);
                        writer.WriteLine(convertedLine);
                    }
                }

                // Sau khi xử lý hết file, thay thế file gốc bằng file tạm
                File.Copy(tempFilePath, filePath, true);
            }
            finally
            {
                // Xóa tệp tạm sau khi sử dụng
                File.Delete(tempFilePath);
            }
        }
        private void ConvertFileEncoding(string filePath, string targetEncoding)
        {
            // Tạo một tệp tạm để lưu trữ kết quả
            string tempFilePath = Path.GetTempFileName();

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var writer = new StreamWriter(tempFilePath, false, Encoding.GetEncoding(targetEncoding)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Chuyển đổi dòng và ghi vào tệp tạm
                        string convertedLine = ConvertToCRLF(line);
                        writer.WriteLine(convertedLine);
                    }
                }

                // Sau khi xử lý hết file, thay thế file gốc bằng file tạm
                File.Copy(tempFilePath, filePath, true);
            }
            finally
            {
                // Xóa tệp tạm sau khi sử dụng
                File.Delete(tempFilePath);
            }
        }

        //Check xem file có phải UTF8-BOm
        private int CheckFileEncoding(string filePath)
        {
            int l_Result = -1;
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] bom = new byte[4]; // UTF-8 BOM có 3 byte, nhưng chúng ta cần 4 byte để đảm bảo không lỗi

                    fs.Read(bom, 0, 4);

                    if (IsUTF8WithBOM(bom))
                    {
                        //File là UTF-8 with BOM;
                        l_Result = 1;
                    }
                    else if (IsUTF8WithoutBOM(bom))
                    {
                        //File là UTF-8 without BOM";
                        l_Result = 2;
                    }
                    else
                    {
                        //File không phải là UTF-8"
                        l_Result = 0;
                    }
                }
            }
            catch (Exception ex)
            {
               l_logger_Fuction.Log($"Error check UTF8: {ex.Message}");
                l_Result = -1;
            }
            return l_Result;
        }

        private bool IsUTF8WithBOM(byte[] bom)
        {
            // UTF-8 BOM: EF BB BF
            return bom.Length >= 3 && bom[0] == 0xEF && bom[1] == 0xBB && bom[2] == 0xBF;
        }

        private bool IsUTF8WithoutBOM(byte[] bom)
        {
            // UTF-8 without BOM
            return bom.Length >= 2 && bom[0] == 0xFF && bom[1] == 0xFE;
        }

        private void btn_FormatFile_Click(object sender, EventArgs e)
        {
            CheckEncodingFolder(l_txtSelectFolder.Text,  comboBox1.SelectedItem.ToString());
            l_logger_Fuction.Log($"Encoding check completed\r\n");
            l_logger_Not_UTF8.Log($" check completed\r\n");
            l_logger_UTF8.Log($" check completed\r\n");
        }

        private void combobox_Lang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Đổi ngôn ngữ tùy thuộc vào nhu cầu của bạn
            CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
            if (combobox_Lang.Text == "English/英語")
            {
                if(culture.Name == "en-US")
                {
                    //Không làm gì hết
                } else
                {
                    //ngược lại set tiếng Nhật cho app
                    SetDefaultLanguage("DefaultLanguage", "en-US");
                    SetLangApplication();
                }    
            }  
            else if(combobox_Lang.Text == "Japanese/日本語")
            {
                if (culture.Name == "ja-JP")
                {
                    //Không làm gì hết
                }
                else
                {
                    //ngược lại set tiếng Nhật cho app
                    SetDefaultLanguage("DefaultLanguage", "ja-JP");
                    //đọc lại file
                    SetLangApplication();
                }
            }
            else
            { 
                //Không làm gì hết
            }
        }
    }
 }
