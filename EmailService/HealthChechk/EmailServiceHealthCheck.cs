using EmailService.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EmailService.HealthChechk;

public class EmailServiceHealthCheck : IHealthCheck
{
    private readonly IEmailService _emailService;

    public EmailServiceHealthCheck(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var isHealthy = await _emailService.CheckEmailService();

        return isHealthy ? 
            HealthCheckResult.Healthy() : 
            HealthCheckResult.Unhealthy();
    }

    
}