namespace MinimalApi.BestPractices.Api.Routes___Practice1.v1
{
    public static class ProductsV1Routes
    {
        const string PATH = "Products";



        public static IEndpointRouteBuilder MapV1Products(this IEndpointRouteBuilder endpoints)
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
