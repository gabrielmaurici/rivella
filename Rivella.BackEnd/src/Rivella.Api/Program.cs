using Rivella.Api.Configurations;
using Rivella.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDbConnection(builder.Configuration);
builder.Services.AddStorageConfiguration(builder.Configuration);
builder.Services.AddUseCases();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddAntiforgery();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Console.WriteLine("app1 "+app.Configuration.GetValue<string>("CLOUDINARY"));
Console.WriteLine("app2 "+app.Configuration.GetValue<string>("RivellaDb"));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterAlbumEndpoints();
app.RegisterPhotoEndpoints();

app.UseHttpsRedirection();
app.Run();