
using System.Reflection.Metadata;

namespace MinimalApi.BestPractices.Api.Extensions
{
    public static class EndpointExtensions
    {
        public static RouteHandlerBuilder AddRequestInfo<TRequest>(this RouteHandlerBuilder builder, string group, string? description = null)
        {

            builder = builder.WithName(typeof(TRequest).Name.Replace("Request", ""))
                .WithTags(group)
                .Produces(200, typeof(TRequest), "application/json");

            if (!string.IsNullOrEmpty(description))
            {
                builder = builder.WithDescription(description);
            }

            return builder;
        }
    }
}
