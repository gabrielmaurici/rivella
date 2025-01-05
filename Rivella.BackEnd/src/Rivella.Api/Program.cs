using Rivella.Api.Configurations;
using Rivella.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDbConnection();
builder.Services.AddStorageConfiguration();
builder.Services.AddUseCases();

builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseCors();
app.UseHealthChecks("/health");
app.RegisterAlbumEndpoints();
app.RegisterPhotoEndpoints();
app.UseHttpsRedirection();
app.Run();