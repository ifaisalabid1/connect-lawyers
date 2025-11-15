using ConnectLawyers.Data;
using ConnectLawyers.Interfaces;
using ConnectLawyers.Mappings;
using ConnectLawyers.Repositories;
using ConnectLawyers.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<ILawFirmRepository, LawFirmRepository>();
builder.Services.AddScoped<ILawyerRepository, LawyerRepository>();

// Mappers
builder.Services.AddScoped<ILawyerMapper, LawyerMapper>();
builder.Services.AddScoped<ILawFirmMapper, LawFirmMapper>();

// Services
builder.Services.AddScoped<ILawFirmService, LawFirmService>();
builder.Services.AddScoped<ILawyerService, LawyerService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
        {
            policy.WithOrigins("http://localhost:3000");
        });
});


builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
