using MyWebAPI.MyLibrary;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// Instantiate your calculator (if it's not static)
var weatherCalculator = new WeatherCalculator();

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
    {
        var date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)); // ✅ fixed
        return new WeatherForecast
        (
            date,
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)],
            weatherCalculator.DetermineSeason(date) // ✅ fixed
        );
    })
    .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary, string Season)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}