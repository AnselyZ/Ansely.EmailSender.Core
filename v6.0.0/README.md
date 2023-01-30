# Ansely.Utility.EmailSender
## 概念：

- 一个简单方便的邮件发送包
- 可以自定义邮件模板，以便在调用具体的Send方法时直接选择某个模板并发送
## 使用：
### 1. 使用内置的邮件模板发送邮件
```csharp
// 创建EmailSender实例并配置相关设置
IEmailSender sender = new EmailSender(new EmailSenderOptions
{
    FromAddr = "xxx@xxx.com", // 发送源地址
    Secret = "xxx",	// 邮件服务器密钥
    Host = "xxx"	// 邮件服务器地址
});

// 创建内置邮件模板，传入邮件显示名称、邮件标题以及邮件内容
var tmp = new EmailTemplate("fromDisplayName", "subject", "body");

// 发送目的地址
var list = new List<string>
{
    "xxx@xxx.com"
};

// 发送
var res = sender.Send(tmp, list);
if(res.Successed)
{
    Console.WriteLine("Successful!");
}
else
{
    foreach(var i in res.Errors)
    {
        Console.WriteLine(i.Description);
    }
}
```
### 2. 自定义邮件模板

- 只需新建一个类并继承自 `AbstractEmailTemplate` 抽象类
- 你将重写如下3个较为重要的属性
- 另外， `AbstractEmailTemplate` 抽象类中还定义了一个 `MailMessage` 类型的属性，有关更多邮件消息的配置可自定义实现
```csharp
public class CustomerEmailTemplate : AbstractEmailTemplate
{
    public CustomerEmailTemplate()
    {
        // Do something...
    	this.MailMessage.IsBodyHtml = true;
    }

    public override string? FromDisplayName { get; protected set; } 
        = "xxx";
    public override string? Subject { get; protected set; } 
        = "xxx";
    public override string? Body { get; protected set; } 
        = "xxx";
}
```
### 3. 有关在Web应用程序中使用的范例

- 包中添加了对Web应用程序依赖注入的扩展支持。它创建了一个**Scope**生命周期的 `IEmailSender` 对象
```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEmailSender(options =>
{
    options.Host = builder.Configuration["Email:Host"];
    options.Secret = builder.Configuration["Email:Secret"];
    options.FromAddr = builder.Configuration["Email:FromAddr"];
});
```
- 在控制器中使用如下
```csharp
public class HomeController : Controller
{
    private readonly IEmailSender emailSender;

    public HomeController(IEmailSender emailSender)
    {
        this.emailSender = emailSender;
    }
}
```
