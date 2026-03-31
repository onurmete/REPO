var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () => new { status = "ok", version = "1.0.0" });

app.Run("http://0.0.0.0:8080");
