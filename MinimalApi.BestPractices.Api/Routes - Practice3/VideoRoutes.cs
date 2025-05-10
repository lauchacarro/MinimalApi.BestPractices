using MinimalApi.BestPractices.Api.Extensions;
using MinimalApi.BestPractices.Application.Models.Videos;
using MinimalApi.BestPractices.Application.Services;

namespace MinimalApi.BestPractices.Api.Routes___Practice3
{
    public static class VideoRoutes
    {
        const string PATH = "Videos";
        public static IEndpointRouteBuilder MapVideos(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup(PATH);



            group.MapGet("/Bad", async (IVideoService service)
             =>
            {
                var result = await service.GetByIdAsync(new GetByIdVideoRequest(Guid.Empty));

                if(result.Data is null)
                {
                    return Results.BadRequest();
                }

                if (result.IsSuccess)
                {
                    return Results.Ok(result.Data);
                }
                else
                {
                    return Results.BadRequest(result.Errors);
                }
            });



            group.MapGet("/", (IVideoService service)
             => service.GetAllAsync(new GetAllVideosRequest()).ToHttpResult())
             .AddRequestInfo<GetAllVideosRequest>(PATH);

            group.MapGet("{id}", (Guid id, IVideoService service)
               => service.GetByIdAsync(new GetByIdVideoRequest(id)).ToHttpResult())
               .AddRequestInfo<GetByIdVideoRequest>(PATH);

            group.MapPost("/", (IVideoService service, CreateVideoRequest request)
             => service.CreateAsync(request).ToHttpResult())
             .AddRequestInfo<CreateVideoRequest>(PATH);

            group.MapPut("/", (IVideoService service, UpdateVideoRequest request)
             => service.UpdateAsync(request).ToHttpResult())
             .AddRequestInfo<UpdateVideoRequest>(PATH);


            group.MapDelete("{id}", (Guid id, IVideoService service)
              => service.DeleteAsync(new DeleteVideoRequest(id)).ToHttpResult())
              .AddRequestInfo<GetByIdVideoRequest>(PATH);

            group.MapPost("/ImageUpload", (IFormFile file, IVideoService service)
                => service.UploadFileAsync(new UploadFileRequest(file.FileName, file.OpenReadStream())).ToHttpResult())
                .AddRequestInfo<UploadFileRequest>(PATH)
                .DisableAntiforgery();

            return group;
        }
    }
}
