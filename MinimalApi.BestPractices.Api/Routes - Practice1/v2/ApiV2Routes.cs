namespace MinimalApi.BestPractices.Api.Routes___Practice1.v2
{
    public static class ApiV2Routes
    {
        const string PATH = "v2";



        public static IEndpointRouteBuilder MapApiV2Endpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup(PATH);

            group.MapV2Users();

            return group;
        }
    }
}
