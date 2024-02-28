using CassInformationSystem.Application.Contracts;
using CassInformationSystemApi.Extensions;
using CassInformationSystemApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors(builder.Configuration.GetSection("CORS:Origins").Value!.ToString());
builder.Services.RegisterServices(builder.Configuration.GetConnectionString("Default")!);
builder.Services.RegisterRepository();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
