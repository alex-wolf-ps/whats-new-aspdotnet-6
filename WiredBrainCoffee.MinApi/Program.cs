using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.MinApi;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Orders") ?? "Data Source=Orders.db";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlite<OrderDbContext>(connectionString);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", builder =>
    {
        builder.AllowAnyOrigin();
    });
});
builder.Services.AddHttpClient();

var app = builder.Build();

await CreateDb(app.Services, app.Logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.Run();

async Task CreateDb(IServiceProvider services, ILogger logger)
{
    using var db = services.CreateScope().ServiceProvider.GetRequiredService<OrderDbContext>();
    await db.Database.MigrateAsync();
}

