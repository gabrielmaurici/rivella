using Microsoft.AspNetCore.Diagnostics;
using Rivella.Api.Configurations;
using Rivella.Api.Endpoints;
using Rivella.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDbConnection();
builder.Services.AddStorageConfiguration();
builder.Services.AddUseCases();

builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ExceptionHandlingMiddleware>();

var rivellaFrontEnd = Environment.GetEnvironmentVariable("rivella-front-end") ??
                      throw new InvalidOperationException("rivella-front-end não encontrado");
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
        config
            .WithOrigins(
                "https://localhost:7278",
                rivellaFrontEnd
            )
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHealthChecks("/health");
app.RegisterAlbumEndpoints();
app.RegisterPhotoEndpoints();
app.Run();