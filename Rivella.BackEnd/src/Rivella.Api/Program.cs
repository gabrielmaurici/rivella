using Rivella.Api.Configurations;
using Rivella.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDbConnection();
builder.Services.AddStorageConfiguration();
builder.Services.AddUseCases();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
        config
            .WithOrigins(
                "https://localhost:7278",
                "https://rivellas.onrender.com"
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

app.UseCors();
app.RegisterAlbumEndpoints();
app.RegisterPhotoEndpoints();
app.UseHttpsRedirection();
app.Run();