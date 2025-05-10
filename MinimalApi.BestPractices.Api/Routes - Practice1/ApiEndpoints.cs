using MinimalApi.BestPractices.Api.Routes___Practice1.v1;
using MinimalApi.BestPractices.Api.Routes___Practice1.v2;

namespace MinimalApi.BestPractices.Api.Routes___Practice1
{
    public static class ApiEndpoints
    {
        const string PATH = "api";



        public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup(PATH);

            group.MapApiV1Endpoints();
            group.MapApiV2Endpoints();

            return group;
        }
    }
}
