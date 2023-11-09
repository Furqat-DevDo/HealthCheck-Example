using EmailService.HealthChechk;
using EmailService.Services;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddHealthChecks()
    .AddCheck<EmailServiceHealthCheck>(nameof(EmailServiceHealthCheck),
        tags: new[] { "email" });

builder.Services.AddScoped<IEmailService,EmailService.Services.EmailService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
