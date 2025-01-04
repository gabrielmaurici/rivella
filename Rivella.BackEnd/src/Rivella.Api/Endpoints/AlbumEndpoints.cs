using Rivella.Application.UseCases.Album.GetAlbum;
using Rivella.Application.UseCases.Album.Common;
using Rivella.Application.UseCases.Album.CreateAlbum;

namespace Rivella.Api.Endpoints;

public static class AlbumEndpoints
{
    public static void RegisterAlbumEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("albums", async (CreateAlbumInput input, ICreateAlbum createAlbum) =>
        {
            var output = await createAlbum.CreateAsync(input);
            return TypedResults.Ok(output);
        })
        .WithName("CreateCustomer")
        .WithOpenApi()
        .Produces(StatusCodes.Status200OK, typeof(AlbumOutput))
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);
        
        endpoints.MapGet("albums/{code:guid}", async (Guid code, IGetAlbum getAlbum) => {
            return TypedResults.Ok(await getAlbum.GetAsync(code));
        })
        .WithName("GetAlbum")
        .WithOpenApi()
        .Produces(StatusCodes.Status200OK, typeof(AlbumOutput))
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);
    }
}