using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Net.Mime;

namespace ScheduledMessenger;

public partial class Form1 : Form
{

    private DateTime sendTime;

    public Form1()
        {
            InitializeComponent();
            // 设置默认时间为当前时间加1分钟
            dateTimePicker1.Value = DateTime.Now.AddMinutes(1);
            btnStop.Enabled = false;
            // 添加Load事件处理程序
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            txtSmtpPort.Text = "587";
            // 添加窗口大小调整事件
            this.Resize += new EventHandler(Form1_Resize);
            // 初始调整一次大小
            AdjustMessageTextBoxSize();
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
        if (string.IsNullOrWhiteSpace(txtSmtpServer.Text))
        {
            MessageBox.Show("请输入SMTP服务器地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            MessageBox.Show("请输入邮箱密码或授权码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // 发送消息
            SendMessage();
            
            // 停止定时器
            timer1.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            dateTimePicker1.Enabled = true;
            txtContact.Enabled = true;
            txtMessage.Enabled = true;
        }
    }

    private void SendMessage()
    {
        try
        {
            // 创建SMTP客户端
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = txtSmtpServer.Text;
                smtpClient.Port = int.Parse(txtSmtpPort.Text);
                smtpClient.EnableSsl = chkEnableSsl.Checked;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(txtSenderEmail.Text, txtSenderPassword.Text);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                // 创建邮件消息
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(txtSenderEmail.Text);
                    mailMessage.To.Add(txtContact.Text);
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
            MessageBox.Show($"邮箱格式错误：{ex.Message}", "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            notifyIcon1.ShowBalloonTip(5000, "定时邮件发送器", "邮箱格式错误！", ToolTipIcon.Error);
        }
        catch (SmtpException ex)
        {
            string errorMessage = "邮件发送失败：";
            switch (ex.StatusCode)
            {
                case SmtpStatusCode.ServiceNotAvailable:
                    errorMessage += "无法连接到SMTP服务器，请检查服务器地址和端口。";
                    break;
                case SmtpStatusCode.ClientNotPermitted:
                    errorMessage += "身份验证失败，请检查邮箱和密码。";
                    break;
                case SmtpStatusCode.MailboxUnavailable:
                    errorMessage += "收件人邮箱不存在或不可用。";
                    break;
                default:
                    errorMessage += ex.Message;
                    break;
            }
            MessageBox.Show(errorMessage, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            notifyIcon1.ShowBalloonTip(5000, "定时邮件发送器", "邮件发送失败！", ToolTipIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"邮件发送失败：{ex.Message}", "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            notifyIcon1.ShowBalloonTip(5000, "定时邮件发送器", "邮件发送失败！", ToolTipIcon.Error);
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
        // 清理资源
        timer1.Stop();
        notifyIcon1.Visible = false;
    }
}
