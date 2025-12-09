using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Net.Mime;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace ScheduledMessenger;

public partial class Form1 : Form
{

    private DateTime sendTime;

    // 定义用户数据类
    public class UserData
    {
        public string SenderEmail { get; set; } = string.Empty;
        public string SenderPassword { get; set; } = string.Empty;
        public string[] RecipientEmails { get; set; } = Array.Empty<string>();
    }

    public Form1()
        {
            InitializeComponent();
            // 设置默认时间为当前时间加1分钟
            dateTimePicker1.Value = DateTime.Now.AddMinutes(1);
            btnStop.Enabled = false;
            // 添加Load事件处理程序
            this.Load += new EventHandler(Form1_Load);
            // 加载用户数据
            LoadUserData();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            txtSmtpPort.Text = "587";
            // 添加窗口大小调整事件
            this.Resize += new EventHandler(Form1_Resize);
            // 初始调整一次大小
            AdjustMessageTextBoxSize();
        }

        // 保存用户数据到文件
        private void SaveUserData()
        {
            try
            {
                // 获取AppData目录
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string appFolderPath = Path.Combine(appDataPath, "ScheduledMessenger");
                string dataFilePath = Path.Combine(appFolderPath, "userdata.json");

                // 创建目录（如果不存在）
                Directory.CreateDirectory(appFolderPath);

                // 解析收件人邮箱
                string[] recipientEmails = txtContact.Text.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(email => email.Trim())
                                .Where(email => !string.IsNullOrWhiteSpace(email))
                                .ToArray();

                // 创建用户数据对象
                UserData userData = new UserData
                {
                    SenderEmail = txtSenderEmail.Text,
                    SenderPassword = txtSenderPassword.Text,
                    RecipientEmails = recipientEmails
                };

                // 序列化并保存到文件
                string json = JsonSerializer.Serialize(userData);
                File.WriteAllText(dataFilePath, json);
            }
            catch (Exception ex)
            {
                // 保存失败不影响程序运行，仅记录错误
                Console.WriteLine("保存用户数据失败: " + ex.Message);
            }
        }

        // 从文件加载用户数据
        private void LoadUserData()
        {
            try
            {
                // 获取AppData目录
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string appFolderPath = Path.Combine(appDataPath, "ScheduledMessenger");
                string dataFilePath = Path.Combine(appFolderPath, "userdata.json");

                // 检查文件是否存在
                if (File.Exists(dataFilePath))
                {
                    // 读取并反序列化数据
                    string json = File.ReadAllText(dataFilePath);
                    UserData userData = JsonSerializer.Deserialize<UserData>(json) ?? new UserData();

                    // 设置界面控件值
                    if (userData != null)
                    {
                        if (!string.IsNullOrWhiteSpace(userData.SenderEmail))
                    {
                        txtSenderEmail.Text = userData.SenderEmail;
                    }

                    if (!string.IsNullOrWhiteSpace(userData.SenderPassword))
                    {
                        txtSenderPassword.Text = userData.SenderPassword;
                    }

                    if (userData.RecipientEmails != null && userData.RecipientEmails.Length > 0)
                    {
                        txtContact.Text = string.Join(", ", userData.RecipientEmails);
                    }
                    }
                }
            }
            catch (Exception ex)
            {
                // 加载失败不影响程序运行，仅记录错误
                Console.WriteLine("加载用户数据失败: " + ex.Message);
            }
        }

        // SMTP服务器选择事件，自动更新端口和SSL设置
        private void cmbSmtpServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSmtpServer.SelectedItem != null)
            {
                string selectedServer = cmbSmtpServer.SelectedItem.ToString();
                switch (selectedServer)
                {
                    case "smtp.qq.com":
                        txtSmtpPort.Text = "587";
                        chkEnableSsl.Checked = true;
                        break;
                    case "smtp.163.com":
                        txtSmtpPort.Text = "587";
                        chkEnableSsl.Checked = true;
                        break;
                    case "smtp.126.com":
                        txtSmtpPort.Text = "587";
                        chkEnableSsl.Checked = true;
                        break;
                    case "smtp.gmail.com":
                        txtSmtpPort.Text = "587";
                        chkEnableSsl.Checked = true;
                        break;
                    case "smtp.office365.com":
                        txtSmtpPort.Text = "587";
                        chkEnableSsl.Checked = true;
                        break;
                    case "smtp.sina.com.cn":
                        txtSmtpPort.Text = "587";
                        chkEnableSsl.Checked = true;
                        break;
                    default:
                        txtSmtpPort.Text = "587";
                        chkEnableSsl.Checked = true;
                        break;
                }
            }
        }

        // 相对时间选择事件处理程序
        private void cmbRelativeTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRelativeTime.SelectedIndex == -1) return;

            DateTime currentTime = DateTime.Now;
            DateTime newTime = currentTime;

            switch (cmbRelativeTime.SelectedIndex)
            {
                case 0: // 10秒后
                    newTime = currentTime.AddSeconds(10);
                    break;
                case 1: // 30秒后
                    newTime = currentTime.AddSeconds(30);
                    break;
                case 2: // 1分钟后
                    newTime = currentTime.AddMinutes(1);
                    break;
                case 3: // 5分钟后
                    newTime = currentTime.AddMinutes(5);
                    break;
                case 4: // 10分钟后
                    newTime = currentTime.AddMinutes(10);
                    break;
                case 5: // 30分钟后
                    newTime = currentTime.AddMinutes(30);
                    break;
                case 6: // 1小时后
                    newTime = currentTime.AddHours(1);
                    break;
                case 7: // 2小时后
                    newTime = currentTime.AddHours(2);
                    break;
                case 8: // 5小时后
                    newTime = currentTime.AddHours(5);
                    break;
                case 9: // 1天后
                    newTime = currentTime.AddDays(1);
                    break;
                default:
                    return; // 选择"选择相对时间"时不做任何操作
            }

            // 更新日期时间选择器
            dateTimePicker1.Value = newTime;
        }

        private void Form1_Resize(object? sender, EventArgs e)
        {
            AdjustMessageTextBoxSize();
        }

        private void AdjustMessageTextBoxSize()
        {
            // 计算消息文本框的新高度
            int buttonHeight = btnStart.Height + btnStop.Height + 20; // 按钮高度加上间距
            int otherControlsHeight = 371; // 消息文本框之前的所有控件高度
            int newHeight = this.ClientSize.Height - otherControlsHeight - buttonHeight - 50; // 50是额外的边距

            // 确保最小高度
            if (newHeight < 120)
                newHeight = 120;

            // 调整文本框大小
            txtMessage.Height = newHeight;
        }

    private void btnStart_Click(object sender, EventArgs e)
    {
        // 验证邮件服务器设置
        if (cmbSmtpServer.SelectedIndex == 0 || cmbSmtpServer.SelectedItem == null || string.IsNullOrWhiteSpace(cmbSmtpServer.SelectedItem.ToString()))
        {
            MessageBox.Show("请选择SMTP服务器地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSmtpPort.Text))
        {
            MessageBox.Show("请输入SMTP端口号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int port;
        if (!int.TryParse(txtSmtpPort.Text, out port))
        {
            MessageBox.Show("SMTP端口号必须是数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSenderEmail.Text))
        {
            MessageBox.Show("请输入发件人邮箱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSenderPassword.Text))
        {
            MessageBox.Show("请输入邮箱授权码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtContact.Text))
        {
            MessageBox.Show("请输入收件人邮箱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSubject.Text))
        {
            MessageBox.Show("请输入邮件主题！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtMessage.Text))
        {
            MessageBox.Show("请输入邮件内容！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        sendTime = dateTimePicker1.Value;
        if (sendTime <= DateTime.Now)
        {
            MessageBox.Show("请选择一个未来的时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        timer1.Start();
        btnStart.Enabled = false;
        btnStop.Enabled = true;
        MessageBox.Show($"定时邮件已设置，将在 {sendTime.ToString("yyyy-MM-dd HH:mm:ss")} 发送！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        // 停止定时器
        timer1.Stop();
        btnStart.Enabled = true;
        btnStop.Enabled = false;
        dateTimePicker1.Enabled = true;
        txtContact.Enabled = true;
        txtMessage.Enabled = true;

        MessageBox.Show("定时任务已停止", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        // 检查是否到达发送时间
        if (DateTime.Now >= sendTime)
        {
            // 停止定时器，防止重复发送和弹窗
            timer1.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            dateTimePicker1.Enabled = true;
            txtContact.Enabled = true;
            txtMessage.Enabled = true;
            
            // 发送消息
            SendMessage();
        }
    }

    private void SendMessage()
    {
        try
        {
            // 创建SMTP客户端
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = cmbSmtpServer.SelectedItem?.ToString() ?? string.Empty;
                smtpClient.Port = int.Parse(txtSmtpPort.Text);
                smtpClient.EnableSsl = chkEnableSsl.Checked;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(txtSenderEmail.Text, txtSenderPassword.Text);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                // 设置超时时间（增加到30秒）
                smtpClient.Timeout = 30000;

                // 创建邮件消息
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(txtSenderEmail.Text);
                    
                    // 处理多个收件人，支持逗号或分号分隔
                    string[] recipients = txtContact.Text.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string recipient in recipients)
                    {
                        if (!string.IsNullOrWhiteSpace(recipient.Trim()))
                        {
                            mailMessage.To.Add(recipient.Trim());
                        }
                    }
                    
                    mailMessage.Subject = txtSubject.Text;
                    mailMessage.Body = txtMessage.Text;
                    mailMessage.IsBodyHtml = false; // 可以根据需要改为true支持HTML邮件

                    // 发送邮件
                    smtpClient.Send(mailMessage);
                }
            }

            // 发送成功通知
            string message = $"邮件已成功发送给：{txtContact.Text}\n主题：{txtSubject.Text}";
            MessageBox.Show(message, "发送成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            notifyIcon1.ShowBalloonTip(5000, "定时邮件发送器", "邮件发送成功！", ToolTipIcon.Info);
        }
        catch (FormatException ex)
        {
            string errorMessage = "邮箱格式错误：";
            if (ex.Message.Contains("txtSmtpPort"))
                errorMessage += "SMTP端口必须是数字格式。";
            else
                errorMessage += "请检查发件人和收件人邮箱格式是否正确。";
            
            MessageBox.Show(errorMessage, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            notifyIcon1.ShowBalloonTip(5000, "定时邮件发送器", errorMessage, ToolTipIcon.Error);
        }
        catch (SmtpException ex)
        {
            string errorMessage = "邮件发送失败：";
            string balloonMessage = "邮件发送失败：";
            
            // 添加调试信息
            string smtpServer = cmbSmtpServer.SelectedItem?.ToString() ?? string.Empty;
            string debugInfo = $"\n\n调试信息：\nSMTP服务器：{smtpServer}\n端口：{txtSmtpPort.Text}\n启用SSL：{chkEnableSsl.Checked}\n发件人：{txtSenderEmail.Text}\n收件人：{txtContact.Text}\n";
            
            switch (ex.StatusCode)
            {
                case SmtpStatusCode.ServiceNotAvailable:
                    errorMessage += "无法连接到SMTP服务器，请检查：\n1. 服务器地址和端口是否正确\n2. 网络连接是否正常\n3. 防火墙是否阻止了连接\n4. 服务器是否允许外部连接" + debugInfo;
                    balloonMessage += "无法连接到SMTP服务器";
                    break;
                case SmtpStatusCode.ClientNotPermitted:
                    errorMessage += "身份验证失败，请检查：\n1. 发件人邮箱地址是否正确\n2. 授权码是否正确（各大邮箱均需要使用授权码而不是登录密码）\n3. 是否在邮箱设置中启用了SMTP服务" + debugInfo;
                    balloonMessage += "身份验证失败";
                    break;
                case SmtpStatusCode.MailboxUnavailable:
                case SmtpStatusCode.MailboxBusy:
                    errorMessage += "收件人邮箱不存在、不可用或正忙，请检查收件人邮箱地址。" + debugInfo;
                    balloonMessage += "收件人邮箱不可用";
                    break;
                case SmtpStatusCode.MustIssueStartTlsFirst:
                    errorMessage += "SSL/TLS配置错误，请检查：\n1. 是否正确设置SSL选项\n2. 服务器是否支持所选的加密方式" + debugInfo;
                    balloonMessage += "SSL/TLS配置错误";
                    break;
                case SmtpStatusCode.ExceededStorageAllocation:
                    errorMessage += "邮件大小超过服务器限制，请减小邮件内容或附件大小。" + debugInfo;
                    balloonMessage += "邮件大小超过限制";
                    break;
                default:
                    errorMessage += $"{ex.Message}\n\n错误代码：{ex.StatusCode}\n\n建议检查：\n1. SMTP服务器配置\n2. 网络连接\n3. 邮箱权限设置\n4. 邮件内容格式" + debugInfo;
                    balloonMessage += "未知错误";
                    break;
            }
            
            MessageBox.Show(errorMessage, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            notifyIcon1.ShowBalloonTip(5000, "定时邮件发送器", balloonMessage, ToolTipIcon.Error);
        }
        catch (ArgumentNullException ex)
        {
            string errorMessage = "缺少必要参数：";
            if (ex.ParamName?.Contains("Host") == true) errorMessage += "请输入SMTP服务器地址";
            else if (ex.ParamName?.Contains("Port") == true) errorMessage += "请输入SMTP端口";
            else if (ex.ParamName?.Contains("From") == true) errorMessage += "请输入发件人邮箱";
            else if (ex.ParamName?.Contains("To") == true) errorMessage += "请输入收件人邮箱";
            else errorMessage += ex.Message;
            
            MessageBox.Show(errorMessage, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            notifyIcon1.ShowBalloonTip(5000, "定时邮件发送器", errorMessage, ToolTipIcon.Error);
        }
        catch (Exception ex)
        {
            // 添加调试信息
            string smtpServer = cmbSmtpServer.SelectedItem?.ToString() ?? string.Empty;
            string debugInfo = $"\n\n调试信息：\nSMTP服务器：{smtpServer}\n端口：{txtSmtpPort.Text}\n启用SSL：{chkEnableSsl.Checked}\n发件人：{txtSenderEmail.Text}\n收件人：{txtContact.Text}\n";
            
            string errorMessage = $"邮件发送失败：{ex.Message}\n\n错误类型：{ex.GetType().Name}\n\n建议检查：\n1. 所有必填字段是否填写完整\n2. 网络连接是否正常\n3. 防火墙设置是否阻止连接\n4. 邮件服务器是否正常运行\n5. 邮箱设置中是否启用了SMTP服务\n6. 是否使用了正确的授权码（而非登录密码）\n" + debugInfo;
            
            MessageBox.Show(errorMessage, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            notifyIcon1.ShowBalloonTip(5000, "定时邮件发送器", "邮件发送失败", ToolTipIcon.Error);
        }
        finally
        {
            // 重置按钮状态
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 保存用户数据
            SaveUserData();
            // 清理资源
            timer1.Stop();
            notifyIcon1.Visible = false;
        }

    private void linkLabelHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        string helpText = "## 使用方法\n\n" +
                          "### 1. 配置SMTP服务器\n\n" +
                          "- **SMTP服务器**：输入您的邮件服务商的SMTP服务器地址（例如：smtp.qq.com, smtp.gmail.com, smtp.163.com）\n" +
                          "- **SMTP端口**：输入对应的SMTP端口（通常为587或465）\n" +
                          "- **启用SSL**：根据邮件服务商要求选择是否启用SSL加密（一般建议启用）\n\n" +
                          "### 2. 配置发件人信息\n\n" +
                          "- **发件人邮箱**：输入您的邮箱地址\n" +
                          "- **邮箱密码**：输入您的邮箱密码或授权码（重要：某些邮箱服务商（如QQ、163）需要使用授权码而非登录密码）\n\n" +
                          "### 3. 设置收件人和邮件内容\n\n" +
                          "- **收件人邮箱**：输入接收邮件的邮箱地址\n" +
                          "- **邮件主题**：输入邮件的主题\n" +
                          "- **邮件内容**：输入邮件的正文内容\n\n" +
                          "### 4. 设置发送时间\n\n" +
                          "- 选择您希望发送邮件的日期和时间（必须是未来的时间）\n\n" +
                          "### 5. 开始定时任务\n\n" +
                          "- 点击\"开始\"按钮，程序将开始计时\n" +
                          "- 到指定时间后，程序会自动发送邮件\n" +
                          "- 发送完成后会显示通知\n\n" +
                          "## 重要说明\n\n" +
                          "### 关于授权码\n\n" +
                          "某些邮箱服务商（如QQ邮箱、网易邮箱）需要使用授权码代替密码来发送邮件：\n\n" +
                          "#### QQ邮箱授权码获取方法：\n" +
                          "1. 登录QQ邮箱\n" +
                          "2. 点击右上角\"设置\" -> \"账户\"\n" +
                          "3. 找到\"POP3/IMAP/SMTP/Exchange/CardDAV/CalDAV服务\"\n" +
                          "4. 开启\"POP3/SMTP服务\"\n" +
                          "5. 按照提示发送短信获取授权码\n\n" +
                          "#### 网易邮箱授权码获取方法：\n" +
                          "1. 登录网易邮箱\n" +
                          "2. 点击右上角\"设置\" -> \"POP3/SMTP/IMAP\"\n" +
                          "3. 开启\"POP3/SMTP服务\"\n" +
                          "4. 按照提示设置授权码\n\n" +
                          "### 常见SMTP服务器配置\n\n" +
                          "| 邮箱服务商 | SMTP服务器 | 端口 | SSL |\n" +
                          "|------------|------------|------|-----|\n" +
                          "| QQ邮箱     | smtp.qq.com | 587 | 是 |\n" +
                          "| 163邮箱    | smtp.163.com | 587 | 是 |\n" +
                          "| Gmail      | smtp.gmail.com | 587 | 是 |\n" +
                          "| Outlook    | smtp.office365.com | 587 | 是 |\n\n" +
                          "## 错误排查\n\n" +
                          "- **无法连接服务器**：检查SMTP服务器地址和端口是否正确\n" +
                          "- **身份验证失败**：检查邮箱地址和密码（授权码）是否正确\n" +
                          "- **收件人邮箱错误**：检查收件人邮箱格式是否正确\n" +
                          "- **SSL错误**：尝试关闭SSL或更换端口\n\n" +
                          "## 注意事项\n\n" +
                          "- 请确保您的网络连接正常\n" +
                          "- 某些网络环境可能会阻止SMTP端口，需要联系网络管理员\n" +
                          "- 建议先测试发送一封即时邮件，确保配置正确";

        // 创建帮助窗口
        Form helpForm = new Form();
        helpForm.Text = "发送失败？解决方案";
        helpForm.Size = new Size(600, 700);
        helpForm.StartPosition = FormStartPosition.CenterScreen;
        helpForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        helpForm.MaximizeBox = false;
        helpForm.MinimizeBox = false;

        // 添加富文本框显示帮助内容
        RichTextBox richTextBox = new RichTextBox();
        richTextBox.Dock = DockStyle.Fill;
        richTextBox.Text = helpText;
        richTextBox.ReadOnly = true;
        richTextBox.ScrollBars = RichTextBoxScrollBars.Both;
        richTextBox.Font = new Font("微软雅黑", 9.5f);
        richTextBox.BackColor = Color.White;

        // 添加关闭按钮
        Button btnClose = new Button();
        btnClose.Text = "关闭";
        btnClose.Size = new Size(80, 30);
        btnClose.Location = new Point((helpForm.ClientSize.Width - btnClose.Width) / 2, helpForm.ClientSize.Height - 60);
        btnClose.Click += (s, args) => helpForm.Close();

        // 将控件添加到帮助窗口
        helpForm.Controls.Add(richTextBox);
        helpForm.Controls.Add(btnClose);

        // 显示帮助窗口
        helpForm.ShowDialog();
    }
}
