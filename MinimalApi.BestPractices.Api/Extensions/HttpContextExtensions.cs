using System.Security.Claims;

namespace MinimalApi.BestPractices.Api.Extensions
{
    public static class HttpContextExtensions
    {
        public static Guid GetUserId(this HttpContext httpContext)
        {
            var user = httpContext?.User;

            if (user is null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            return Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }


        public static Guid? GetUserIdOrDefault(this HttpContext httpContext)
        {
            var user = httpContext?.User;

            if (user is null)
            {
                return null;
            }

            var subClaim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (subClaim is not null && Guid.TryParse(subClaim.Value, out Guid userId))
            {
                return userId;
            }

            return null;
        }


        public static IEnumerable<string> GetRoles(this HttpContext httpContext)
        {
            var user = httpContext?.User;

            if (user is null)
            {
                return Enumerable.Empty<string>();
            }

            var roles = user.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);

            return roles;
        }

    }
}
