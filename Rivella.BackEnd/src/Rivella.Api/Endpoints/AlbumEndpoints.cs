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


        // endpoints.MapGet("customers/{id}", async (int id, IGetCustomerService getCustomerService) => {
        //
        //         return TypedResults.Ok(await getCustomerService.GetAsync(id));
        //     })
        //     .WithName("GetCustomer")
        //     .WithOpenApi();
    }
}