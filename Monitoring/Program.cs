var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecksUI(setupSettings: setup =>
    {
        // Har nechi sekunda zapros tashashi
        setup.SetEvaluationTimeInSeconds(2);
        // Bir vaqtda nechta zapros tashashi
        setup.SetApiMaxActiveRequests(1);
        // UI uchun faqat bazaga tegmaydi .
        setup.MaximumHistoryEntriesPerEndpoint(50);

    })
    .AddInMemoryStorage();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecksUI();
app.Run();
