using Microsoft.AspNetCore.HttpLogging;
using WiredBrainCoffee.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAntiforgery(x => x.SuppressXFrameOptionsHeader = true);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("Default", builder =>
//    {
//        builder.AllowAnyOrigin();
//        builder.AllowAnyHeader();
//        builder.AllowAnyMethod();
//    });
//});

builder.Services.AddHttpLogging(httpLogging =>
{
    httpLogging.LoggingFields = HttpLoggingFields.All;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    context.Request.Headers.AcceptLanguage = "C# Forever";
    context.Response.Headers.XPoweredBy = "ASPNETCORE 6.0";
    await next.Invoke(context);
});

app.UseHttpLogging();

app.UseHttpsRedirection();
// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials
app.UseAuthorization();
app.MapControllers();

app.MapHub<ChatHub>("/chathub");

app.Run();
