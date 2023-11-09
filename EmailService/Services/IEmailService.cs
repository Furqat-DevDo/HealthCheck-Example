namespace EmailService.Services;

public interface IEmailService
{
    Task<bool> CheckEmailService();
}