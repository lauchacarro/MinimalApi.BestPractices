using MinimalApi.BestPractices.Api.Extensions;
using MinimalApi.BestPractices.Application.Models.Sales;
using MinimalApi.BestPractices.Application.Models.Videos;
using MinimalApi.BestPractices.Application.Services;

namespace MinimalApi.BestPractices.Api.Routes___Practice4
{
    public static class SalesRoutes
    {
        const string PATH = "Sales";
        public static IEndpointRouteBuilder MapSales(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup(PATH);



            group.MapPost("/", (CreateSalesRequest request, ISalesService service)
             => service.CreateAsync(request).ToHttpResult())
             .WithInfo<CreateVideoResponse>(PATH);



            return group;
        }
    }
}
