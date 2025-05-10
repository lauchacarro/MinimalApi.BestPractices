using MinimalApi.BestPractices.Api.Extensions;

namespace MinimalApi.BestPractices.Api.Routes___Practice2
{
    public static class BlogPostsRoutes
    {
        const string PATH = "BlogPosts";

        public static IEndpointRouteBuilder MapBlogPosts(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup(PATH);


            group.MapGet("/", () =>
            {
                return Results.Ok();
            }).WithName("GetAllBlogPosts")
              .WithTags("BlogPosts")
              .Produces(200)
              .Produces(400)
              .WithMetadata(new ProducesResponseTypeMetadata(200, typeof(BlogPostResponse)))
              .WithDescription("Get all blog posts");


            group.MapGet("/lite", () =>
            {
                return Results.Ok();
            }).AddRequestInfo<GetLiteBlogPostRequest>(PATH, "Get all blog posts with lite info");


            return group;
        }
    }
}

public class GetLiteBlogPostRequest
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class BlogPostResponse
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
