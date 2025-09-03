using BackendDevelopmentTask;
using BackendDevelopmentTask.API.DI;

var builder = WebApplication.CreateBuilder(args);

MapsterConfig.RegisterMappings();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddAPIDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();