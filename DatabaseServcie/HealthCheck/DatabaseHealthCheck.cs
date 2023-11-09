using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DatabaseServcie.HealthCheck;

public class DatabaseHealthCheck : IHealthCheck
{
    public async  Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        var isHealthy = await IsConnected();

        return isHealthy ? 
            HealthCheckResult.Healthy() : 
            HealthCheckResult.Unhealthy();
    }

    public async Task<bool> IsConnected()
    {
        return true;
    }
}