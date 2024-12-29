using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Rivella.Blazor;
using Rivella.Blazor.Services.Album.CreateAlbum;
using Rivella.Blazor.Services.Album.GetAlbum;
using Rivella.Blazor.Services.Album.UploadPhoto;
using Rivella.Blazor.Services.RivellaApi;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var environment = builder.HostEnvironment.IsDevelopment() ? "Development" : "Production";
builder.Configuration.AddJsonFile(
    $"appsettings.{environment}.json",
    optional: false,
    reloadOnChange: true
);

builder.Services.AddHttpClient<IRivellaApiService, RivellaApiService>("rivella-api", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("rivella-api")!);
});

builder.Services.AddTransient<IRivellaApiService, RivellaApiService>();
builder.Services.AddTransient<ICreateAlbumService, CreateAlbumService>();
builder.Services.AddTransient<IUploadPhotoService, UploadPhotoService>();
builder.Services.AddTransient<IGetAlbumService, GetAlbumService>();


await builder.Build().RunAsync();