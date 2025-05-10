namespace MinimalApi.BestPractices.Application.Models.Videos
{

    public record GetAllVideosRequest();

    public record GetByIdVideoRequest(Guid Id);

    public record DeleteVideoRequest(Guid Id);

    public record CreateVideoRequest(string Title, string Description, string Url);

    public record UpdateVideoRequest(Guid Id, string Title, string Description, string Url);

    public record UploadFileRequest(string FileName, Stream FileStream);
}
