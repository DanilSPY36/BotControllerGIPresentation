using BotControllerGIPresentation.Services.UserServices;
using SharedLibrary.DataTransferObjects;

namespace BotControllerGIPresentationServer.Endpoints.UserEndpoints
{
    public static class UserEndpoint
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app) 
        {
            app.MapPost("register", Register);
            app.MapPost("login", Login);

            return app;
        }

        private static async Task<IResult> Register(UserService userService, UserRegisterDto userRegisterDto) 
        {
            await userService.Register(userRegisterDto.UserName, userRegisterDto.Email, userRegisterDto.Password);
            return Results.Ok();
        }

        private static async Task<IResult> Login() 
        {
            return Results.Ok();

        }
    }
}
