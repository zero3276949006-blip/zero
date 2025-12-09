# 定时邮件发送器

一个功能完整的Windows Forms应用程序，可以设置定时发送真实的电子邮件。

## 功能特点

- 设置发送时间
- 配置SMTP服务器参数
- 支持SSL加密
- 输入发件人邮箱和密码（授权码）
- 输入收件人邮箱
- 设置邮件主题和内容
- 开始/停止定时任务
- 详细的发送状态通知
- 完整的错误处理
- 简单易用的界面

## 使用方法

### 1. 配置SMTP服务器

- **SMTP服务器**：输入您的邮件服务商的SMTP服务器地址（例如：smtp.qq.com, smtp.gmail.com, smtp.163.com）
- **SMTP端口**：输入对应的SMTP端口（通常为587或465）
- **启用SSL**：根据邮件服务商要求选择是否启用SSL加密（一般建议启用）

### 2. 配置发件人信息

- **发件人邮箱**：输入您的邮箱地址
- **邮箱密码**：输入您的邮箱密码或授权码（重要：某些邮箱服务商（如QQ、163）需要使用授权码而非登录密码）

### 3. 设置收件人和邮件内容

- **收件人邮箱**：输入接收邮件的邮箱地址
- **邮件主题**：输入邮件的主题
- **邮件内容**：输入邮件的正文内容

### 4. 设置发送时间

- 选择您希望发送邮件的日期和时间（必须是未来的时间）

### 5. 开始定时任务

- 点击"开始"按钮，程序将开始计时
- 到指定时间后，程序会自动发送邮件
- 发送完成后会显示通知

## 重要说明

### 关于授权码

某些邮箱服务商（如QQ邮箱、网易邮箱）需要使用授权码代替密码来发送邮件：

#### QQ邮箱授权码获取方法：
1. 登录QQ邮箱
2. 点击右上角"设置" -> "账户"
3. 找到"POP3/IMAP/SMTP/Exchange/CardDAV/CalDAV服务"
4. 开启"POP3/SMTP服务"
5. 按照提示发送短信获取授权码

#### 网易邮箱授权码获取方法：
1. 登录网易邮箱
2. 点击右上角"设置" -> "POP3/SMTP/IMAP"
3. 开启"POP3/SMTP服务"
4. 按照提示设置授权码

### 常见SMTP服务器配置

| 邮箱服务商 | SMTP服务器 | 端口 | SSL |
|------------|------------|------|-----|
| QQ邮箱     | smtp.qq.com | 587 | 是 |
| 163邮箱    | smtp.163.com | 587 | 是 |
| Gmail      | smtp.gmail.com | 587 | 是 |
| Outlook    | smtp.office365.com | 587 | 是 |

## 错误排查

- **无法连接服务器**：检查SMTP服务器地址和端口是否正确
- **身份验证失败**：检查邮箱地址和密码（授权码）是否正确
- **收件人邮箱错误**：检查收件人邮箱格式是否正确
- **SSL错误**：尝试关闭SSL或更换端口

## 注意事项

- 请确保您的网络连接正常
- 某些网络环境可能会阻止SMTP端口，需要联系网络管理员
- 建议先测试发送一封即时邮件，确保配置正确

## 项目结构

```
ScheduledMessenger/
├── Form1.cs              # 主窗体逻辑
├── Form1.Designer.cs     # 窗体设计器代码
├── Program.cs            # 程序入口
├── ScheduledMessenger.csproj  # 项目配置
└── README.md             # 项目说明
```

## 开发环境

- .NET 9.0
- Visual Studio 2022 或 Visual Studio Code
- Windows 10/11
## 编译和打包

### 版本说明

项目提供两种发布版本，用户可以根据自己的需求选择：

#### 1. 非自包含版本（推荐，文件体积小）
- **特点**：文件体积小（约170KB），但需要用户安装.NET 9.0运行时
- **适用场景**：用户电脑上已安装或愿意安装.NET 9.0运行时

#### 2. 自包含版本
- **特点**：文件体积大（约110MB），包含所有必要的运行时组件
- **适用场景**：用户电脑上没有.NET 9.0运行时，或者需要在多台电脑上分发使用

### 使用命令行编译

#### 编译非自包含版本

```powershell
dotnet publish -c Release -r win-x64 --self-contained false /p:PublishSingleFile=true
```

生成的可执行文件将位于：
`bin\Release\net9.0-windows\win-x64\publish\ScheduledMessenger.exe`

#### 编译自包含版本

```powershell
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
```

生成的可执行文件将位于：
`bin\Release\net9.0-windows\win-x64\publish_self_contained\ScheduledMessenger.exe`

## 注意事项

1. 程序需要Windows操作系统环境
2. 程序在后台运行时会在系统托盘中显示图标
3. 建议将程序放在非系统盘目录下运行