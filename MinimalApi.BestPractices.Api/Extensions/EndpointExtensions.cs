using MinimalApi.BestPractices.Api.Filters;

namespace MinimalApi.BestPractices.Api.Extensions
{
    public static class EndpointExtensions
    {
        public static RouteHandlerBuilder WithInfo<TResponse>(this RouteHandlerBuilder builder, string group, string? description = null)
        {

            builder = builder.WithName(typeof(TResponse).Name.Replace("Response", ""))
                .WithTags(group)
                .Produces(200, typeof(TResponse), "application/json");

            if (!string.IsNullOrEmpty(description))
            {
                builder = builder.WithDescription(description);
            }

            return builder;
        }
    }
}
