using MinimalApi.BestPractices.Api.Extensions;
using MinimalApi.BestPractices.Application.Interfaces;

namespace MinimalApi.BestPractices.Api.Filters
{

    public class UserRoleRouteFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var userId = context.HttpContext.GetUserIdOrDefault();
            var roles = context.HttpContext.GetRoles();

            foreach (var argument in context.Arguments)
            {
                if (argument is IUserId request && userId.HasValue)
                {
                    request.UserId = userId.Value;
                }

                if (argument is IRole requestRole)
                {
                    requestRole.Roles = roles;
                }
            }

            return await next(context);
        }
    }

}
