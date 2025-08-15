namespace SmartClean.Api.Configuration;

public class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; } = new();
    public EmailSettings EmailSettings { get; set; } = new();
    public LoggingSettings LoggingSettings { get; set; } = new();
    public SecuritySettings SecuritySettings { get; set; } = new();
}

public class ConnectionStrings
{
    public string DefaultConnection { get; set; } = string.Empty;
}

public class EmailSettings
{
    public string SmtpServer { get; set; } = string.Empty;
    public int SmtpPort { get; set; }
    public string SmtpUsername { get; set; } = string.Empty;
    public string SmtpPassword { get; set; } = string.Empty;
    public bool EnableSsl { get; set; }
    public string FromEmail { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
}

public class LoggingSettings
{
    public string LogLevel { get; set; } = "Information";
    public string LogFilePath { get; set; } = "logs/log-.txt";
    public bool EnableConsoleLogging { get; set; } = true;
    public bool EnableFileLogging { get; set; } = true;
}

public class SecuritySettings
{
    public string JwtSecret { get; set; } = string.Empty;
    public int JwtExpirationMinutes { get; set; } = 60;
    public bool RequireHttps { get; set; } = true;
}
