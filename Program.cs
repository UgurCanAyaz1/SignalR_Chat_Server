using SignalR_Chat_Server.SignalR;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

// Enabling CORS for all origins
builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", builder =>
    {
        builder.SetIsOriginAllowed((host) => true)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); // Allow credentials
    });
});

var app = builder.Build();

app.Services.GetService(typeof(IHubContext<MessageHub>));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Cors");

app.UseRouting(); // Routing kullanımı

app.UseAuthorization();

app.MapControllers();

// Arranging the endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MessageHub>("/messageHub");
    endpoints.MapControllers();
});

app.Run();
