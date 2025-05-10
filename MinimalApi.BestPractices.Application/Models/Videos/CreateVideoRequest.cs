namespace MinimalApi.BestPractices.Application.Models.Videos
{

    public record GetAllVideosRequest();
    public record GetAllVideosResponse();

    public record GetByIdVideoRequest(Guid Id);
    public record GetByIdVideoResponse(Guid Id);

    public record DeleteVideoRequest(Guid Id);
    public record DeleteVideoResponse();

    public record CreateVideoRequest(string Title, string Description, string Url);
    public record CreateVideoResponse(string Title, string Description, string Url);

    public record UpdateVideoRequest(Guid Id, string Title, string Description, string Url);
    public record UpdateVideoResponse(Guid Id, string Title, string Description, string Url);

    public record UploadFileRequest(string FileName, Stream FileStream);
    public record UploadFileResponse(string FileName);
}
