using ZARoutePlanner.Api;
using ZARoutePlanner.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

const string linesData = "Lines.json";
builder.Services.AddRoutesGraph(linesData);

builder.Services.AddSingleton<RoutesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors((c) => c.AllowAnyOrigin());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();