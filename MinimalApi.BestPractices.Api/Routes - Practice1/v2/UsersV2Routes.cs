namespace MinimalApi.BestPractices.Api.Routes___Practice1.v2
{
    public static class UsersV2Routes
    {
        const string PATH = "Users";



        public static IEndpointRouteBuilder MapV2Users(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup(PATH);


            group.MapGet("/", () =>
            {
                return Results.Ok();
            });



            return group;
        }
    }
}
