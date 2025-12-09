namespace ScheduledMessenger;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dateTimePicker1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtContact;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtMessage;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cmbSmtpServer;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtSmtpPort;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtSenderEmail;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtSenderPassword;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtSubject;
    private System.Windows.Forms.CheckBox chkEnableSsl;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ComboBox cmbRelativeTime;
    private System.Windows.Forms.FlowLayoutPanel sendTimePanel;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSmtpServer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSmtpPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSenderEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSenderPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkEnableSsl = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRelativeTime = new System.Windows.Forms.ComboBox();
            this.sendTimePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.sendTimePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.sendTimePanel);
        this.flowLayoutPanel1.Controls.Add(this.label4);
        this.flowLayoutPanel1.Controls.Add(this.cmbSmtpServer);
        this.flowLayoutPanel1.Controls.Add(this.label5);
        this.flowLayoutPanel1.Controls.Add(this.txtSmtpPort);
        this.flowLayoutPanel1.Controls.Add(this.chkEnableSsl);
        this.flowLayoutPanel1.Controls.Add(this.label6);
        this.flowLayoutPanel1.Controls.Add(this.txtSenderEmail);
        this.flowLayoutPanel1.Controls.Add(this.label7);
        this.flowLayoutPanel1.Controls.Add(this.txtSenderPassword);
        this.flowLayoutPanel1.Controls.Add(this.label2);
        this.flowLayoutPanel1.Controls.Add(this.txtContact);
        this.flowLayoutPanel1.Controls.Add(this.label8);
        this.flowLayoutPanel1.Controls.Add(this.txtSubject);
        this.flowLayoutPanel1.Controls.Add(this.label3);
        this.flowLayoutPanel1.Controls.Add(this.txtMessage);
        this.flowLayoutPanel1.Controls.Add(this.btnStart);
        this.flowLayoutPanel1.Controls.Add(this.btnStop);
        this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
        this.flowLayoutPanel1.Size = new System.Drawing.Size(600, 450);
        this.flowLayoutPanel1.TabIndex = 0;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label1.Location = new System.Drawing.Point(20, 20);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(88, 20);
        this.label1.TabIndex = 0;
        this.label1.Text = "发送时间：";
            // 
            // sendTimePanel
            // 
            this.sendTimePanel.Controls.Add(this.dateTimePicker1);
            this.sendTimePanel.Controls.Add(this.label9);
            this.sendTimePanel.Controls.Add(this.cmbRelativeTime);
            this.sendTimePanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.sendTimePanel.Location = new System.Drawing.Point(20, 43);
            this.sendTimePanel.Name = "sendTimePanel";
            this.sendTimePanel.Size = new System.Drawing.Size(557, 30);
            this.sendTimePanel.TabIndex = 1;
        // 
        // dateTimePicker1
        // 
        this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.dateTimePicker1.Location = new System.Drawing.Point(3, 3);
        this.dateTimePicker1.Name = "dateTimePicker1";
        this.dateTimePicker1.Size = new System.Drawing.Size(200, 27);
        this.dateTimePicker1.TabIndex = 0;
        // 
        // label9
        // 
        this.label9.AutoSize = true;
        this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label9.Location = new System.Drawing.Point(209, 3);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(98, 20);
        this.label9.TabIndex = 1;
        this.label9.Text = "或相对时间：";
        // 
        // cmbRelativeTime
        // 
        this.cmbRelativeTime.FormattingEnabled = true;
        this.cmbRelativeTime.Items.AddRange(new object[] {
        "选择相对时间",
        "10秒后",
        "30秒后",
        "1分钟后",
        "5分钟后",
        "10分钟后",
        "30分钟后",
        "1小时后",
        "2小时后",
        "5小时后",
        "1天后"});
        this.cmbRelativeTime.Location = new System.Drawing.Point(313, 3);
        this.cmbRelativeTime.Name = "cmbRelativeTime";
        this.cmbRelativeTime.Size = new System.Drawing.Size(200, 28);
        this.cmbRelativeTime.TabIndex = 2;
        this.cmbRelativeTime.Text = "选择相对时间";
        this.cmbRelativeTime.SelectedIndexChanged += new System.EventHandler(this.cmbRelativeTime_SelectedIndexChanged);
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label2.Location = new System.Drawing.Point(20, 268);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(98, 20);
        this.label2.TabIndex = 10;
        this.label2.Text = "收件人邮箱：";
        // 
        // txtContact
        // 
        this.txtContact.Location = new System.Drawing.Point(20, 291);
        this.txtContact.Name = "txtContact";
        this.txtContact.PlaceholderText = "请输入收件人邮箱地址，多个地址用逗号或分号分隔";
        this.txtContact.Size = new System.Drawing.Size(557, 27);
        this.txtContact.TabIndex = 11;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label3.Location = new System.Drawing.Point(20, 348);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(88, 20);
        this.label3.TabIndex = 14;
        this.label3.Text = "邮件内容：";
        // 
        // txtMessage
        // 
        this.txtMessage.Location = new System.Drawing.Point(20, 371);
        this.txtMessage.Multiline = true;
        this.txtMessage.Name = "txtMessage";
        this.txtMessage.PlaceholderText = "请输入邮件内容";
        this.txtMessage.Size = new System.Drawing.Size(557, 120);
        this.txtMessage.TabIndex = 15;
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label4.Location = new System.Drawing.Point(20, 126);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(88, 20);
        this.label4.TabIndex = 4;
        this.label4.Text = "SMTP服务器：";
        // 
        // cmbSmtpServer
        // 
        this.cmbSmtpServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbSmtpServer.FormattingEnabled = true;
        this.cmbSmtpServer.Items.AddRange(new object[] {"请选择", "smtp.qq.com", "smtp.163.com", "smtp.126.com", "smtp.gmail.com", "smtp.office365.com", "smtp.sina.com.cn"});
        this.cmbSmtpServer.Location = new System.Drawing.Point(20, 149);
        this.cmbSmtpServer.Name = "cmbSmtpServer";
        this.cmbSmtpServer.Size = new System.Drawing.Size(557, 28);
        this.cmbSmtpServer.TabIndex = 5;
        this.cmbSmtpServer.SelectedIndex = 1; // 默认选择QQ邮箱
        this.cmbSmtpServer.SelectedIndexChanged += new System.EventHandler(this.cmbSmtpServer_SelectedIndexChanged);
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label5.Location = new System.Drawing.Point(20, 126);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(68, 20);
        this.label5.TabIndex = 4;
        this.label5.Text = "SMTP端口：";
        // 
        // txtSmtpPort
        // 
        this.txtSmtpPort.Location = new System.Drawing.Point(20, 149);
        this.txtSmtpPort.Name = "txtSmtpPort";
        this.txtSmtpPort.PlaceholderText = "例如：587";
        this.txtSmtpPort.Size = new System.Drawing.Size(100, 27);
        this.txtSmtpPort.TabIndex = 5;
        this.txtSmtpPort.Text = "587";
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label6.Location = new System.Drawing.Point(20, 198);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(88, 20);
        this.label6.TabIndex = 8;
        this.label6.Text = "发件人邮箱：";
        // 
        // txtSenderEmail
        // 
        this.txtSenderEmail.Location = new System.Drawing.Point(20, 221);
        this.txtSenderEmail.Name = "txtSenderEmail";
        this.txtSenderEmail.PlaceholderText = "请输入发件人邮箱";
        this.txtSenderEmail.Size = new System.Drawing.Size(557, 27);
        this.txtSenderEmail.TabIndex = 9;
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label7.Location = new System.Drawing.Point(20, 248);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(88, 20);
        this.label7.TabIndex = 12;
        this.label7.Text = "授权码：";
        // 
        // txtSenderPassword
        // 
        this.txtSenderPassword.Location = new System.Drawing.Point(20, 271);
        this.txtSenderPassword.Name = "txtSenderPassword";
        this.txtSenderPassword.PasswordChar = '*';
        this.txtSenderPassword.PlaceholderText = "请输入邮箱授权码";
        this.txtSenderPassword.Size = new System.Drawing.Size(557, 27);
        this.txtSenderPassword.TabIndex = 13;
        // 
        // label8
        // 
        this.label8.AutoSize = true;
        this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.label8.Location = new System.Drawing.Point(20, 301);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(68, 20);
        this.label8.TabIndex = 16;
        this.label8.Text = "邮件主题：";
        // 
        // txtSubject
        // 
        this.txtSubject.Location = new System.Drawing.Point(20, 324);
        this.txtSubject.Name = "txtSubject";
        this.txtSubject.PlaceholderText = "请输入邮件主题";
        this.txtSubject.Size = new System.Drawing.Size(557, 27);
        this.txtSubject.TabIndex = 17;
        // 
        // btnStart
        // 
        this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        this.btnStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnStart.ForeColor = System.Drawing.Color.White;
        this.btnStart.Location = new System.Drawing.Point(20, 497);
        this.btnStart.Name = "btnStart";
        this.btnStart.Size = new System.Drawing.Size(100, 40);
        this.btnStart.TabIndex = 18;
        this.btnStart.Text = "开始";
        this.btnStart.UseVisualStyleBackColor = false;
        this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
        // 
        // btnStop
        // 
        this.btnStop.BackColor = System.Drawing.Color.Red;
        this.btnStop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnStop.ForeColor = System.Drawing.Color.White;
        this.btnStop.Location = new System.Drawing.Point(126, 497);
        this.btnStop.Name = "btnStop";
        this.btnStop.Size = new System.Drawing.Size(100, 40);
        this.btnStop.TabIndex = 19;
        this.btnStop.Text = "停止";
        this.btnStop.UseVisualStyleBackColor = false;
        this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
        // 
        // notifyIcon1
        // 
        this.notifyIcon1.Text = "定时邮件发送器";
        this.notifyIcon1.Visible = true;
        // 
        // timer1
        // 
        this.timer1.Interval = 1000;
        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        // 
        // chkEnableSsl
        // 
        this.chkEnableSsl.AutoSize = true;
        this.chkEnableSsl.Checked = true;
        this.chkEnableSsl.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkEnableSsl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.chkEnableSsl.Location = new System.Drawing.Point(20, 179);
        this.chkEnableSsl.Name = "chkEnableSsl";
        this.chkEnableSsl.Size = new System.Drawing.Size(81, 24);
        this.chkEnableSsl.TabIndex = 7;
        this.chkEnableSsl.Text = "启用SSL";
        this.chkEnableSsl.UseVisualStyleBackColor = true;
        // 
        // label9
        // 
        this.label9.AutoSize = true;
        this.label9.Location = new System.Drawing.Point(20, 99);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(95, 12);
        this.label9.TabIndex = 3;
        this.label9.Text = "或相对时间：";
        // 
        // cmbRelativeTime
        // 
        this.cmbRelativeTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbRelativeTime.FormattingEnabled = true;
        this.cmbRelativeTime.Items.AddRange(new object[] {
        "10秒后",
        "30秒后",
        "1分钟后",
        "5分钟后",
        "10分钟后",
        "30分钟后",
        "1小时后",
        "2小时后",
        "5小时后",
        "1天后"});
        this.cmbRelativeTime.Location = new System.Drawing.Point(20, 114);
        this.cmbRelativeTime.Name = "cmbRelativeTime";
        this.cmbRelativeTime.Size = new System.Drawing.Size(208, 20);
        this.cmbRelativeTime.TabIndex = 4;
        this.cmbRelativeTime.Text = "选择相对时间";
        this.cmbRelativeTime.SelectedIndexChanged += new System.EventHandler(this.cmbRelativeTime_SelectedIndexChanged);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(600, 550);
        this.Controls.Add(this.flowLayoutPanel1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.MaximizeBox = true;
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "定时邮件发送器";
        // 将相对时间控件添加到flowLayoutPanel1中
        this.flowLayoutPanel1.Controls.Add(this.label9);
        this.flowLayoutPanel1.Controls.Add(this.cmbRelativeTime);
        // 添加"发送失败？"链接标签
        this.linkLabelHelp = new System.Windows.Forms.LinkLabel();
        this.linkLabelHelp.AutoSize = true;
        this.linkLabelHelp.Location = new System.Drawing.Point(20, 451);
        this.linkLabelHelp.Name = "linkLabelHelp";
        this.linkLabelHelp.Size = new System.Drawing.Size(150, 20);
        this.linkLabelHelp.TabIndex = 20;
        this.linkLabelHelp.TabStop = true;
        this.linkLabelHelp.Text = "发送失败？点击查看解决方案";
        this.linkLabelHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHelp_LinkClicked);
        this.flowLayoutPanel1.Controls.Add(this.linkLabelHelp);

        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        this.sendTimePanel.ResumeLayout(false);
            this.sendTimePanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.LinkLabel linkLabelHelp;
}
