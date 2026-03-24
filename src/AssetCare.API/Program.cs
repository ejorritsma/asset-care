using AssetCare.API.Contracts;
using AssetCare.Application.Assets;
using AssetCare.Application.Assets.Commands;
using AssetCare.Infrastructure.Persistence;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add the database context to be used for database operations
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields =
        HttpLoggingFields.RequestMethod
        | HttpLoggingFields.RequestPath
        | HttpLoggingFields.ResponseStatusCode
        | HttpLoggingFields.Duration;
});

// If anyone asks for the IAssetRepository, give them the AssetRepository from Infrastructure that talks with the database via EF Core.
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<AssetService>();

// Register the API Controllers
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpLogging();

// Add endpoints for controller actions
app.MapControllers();

app.Run();
