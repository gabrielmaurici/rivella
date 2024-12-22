using Microsoft.AspNetCore.Mvc;
using Rivella.Api.Models;
using Rivella.Application.UseCases.Photo.UploadPhoto;

namespace Rivella.Api.Endpoints;

public static class PhotoEndpoints
{
    public static void RegisterPhotoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("photos/upload", async ([FromForm] UploadPhotoInputApi input, IUploadPhoto uploadPhoto) =>
        {
            var inputUpload = input.ToUploadPhotoInput();
            await uploadPhoto.Upload(inputUpload);
            return TypedResults.Created();
        })
        .WithName("UploadPhoto")
        .WithOpenApi()
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError)
        .DisableAntiforgery();
    }
}