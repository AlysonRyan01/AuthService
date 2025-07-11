using Application.Requests.Users.Commands;
using MediatR;

namespace API.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/v1/login", async (
            LoginUserCommand command,
            ISender handler) =>
        {
            var result = await handler.Send(command);
            if (!result.Success)
                return Results.Problem(result.Message);

            return Results.Ok(result.Data);
        });

        app.MapPost("/v1/register", async (
            RegisterUserCommand command, 
            ISender handler) =>
        {
            var result = await handler.Send(command);
            if (!result.Success)
                return Results.Problem(result.Message);
            
            return Results.Ok(result);
        });
    }
}