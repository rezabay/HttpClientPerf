using Microsoft.Extensions.Http;
using Polly;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var services = builder.Services;

services.AddHttpClient("TestClient")
    .ConfigurePrimaryHttpMessageHandler(() =>
        new HttpClientHandler
        {
            MaxConnectionsPerServer = 24
        }
    )
    .AddHttpMessageHandler(() =>
    {
        // Retry connection errors 3 times with increasing delays
        var policy = Policy<HttpResponseMessage>.Handle<HttpRequestException>()
            .WaitAndRetryAsync(3, n => TimeSpan.FromMilliseconds(n * 250));
    
        return new PolicyHttpMessageHandler(policy);
    });

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
