using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Payment.Web.Application;
using Payment.Web.Components;
using Payment.Web.Controllers;
using Payment.Web.Infrastructure.Database;
using Payment.Web.Infrastructure.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddHttpClients(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policyBuilder =>
        {
            policyBuilder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyOrigin();
        });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PaymentDbContext>();
    dbContext.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseCors("AllowAllOrigins");

app.Use(async (context, next) =>
{
    var ipAddress = context.Connection.RemoteIpAddress?.ToString();
    var timeStamp = DateTime.UtcNow.ToString("O");
    var logMessage = $"{timeStamp} - {ipAddress}";
    var logFilePath = Environment.GetEnvironmentVariable("LOG_FILE_PATH");
    if (!string.IsNullOrEmpty(logFilePath))
    {
        await using var stream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.None);
        await using var writer = new StreamWriter(stream);
        await writer.WriteLineAsync(logMessage);
    }
    await next.Invoke();
});

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapHistoryApi();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();