using MongoDB.Driver;
using SearchService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapControllers();

try
{
    await DbInitializer.Init(app);
}
catch(Exception e)
{
    Console.WriteLine(e);
}

app.Run();
