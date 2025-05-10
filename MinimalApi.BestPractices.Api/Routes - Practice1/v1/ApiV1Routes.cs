namespace MinimalApi.BestPractices.Api.Routes___Practice1.v1
{
    public static class ApiV1Routes
    {
        const string PATH = "v1";



        public static IEndpointRouteBuilder MapApiV1Endpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup(PATH);

            group.MapV1Products();

            return group;
        }
    }
}
