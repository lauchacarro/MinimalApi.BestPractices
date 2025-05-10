
using MinimalApi.BestPractices.Application.Models.Results;
using MinimalApi.BestPractices.Application.Models.Videos;

namespace MinimalApi.BestPractices.Application.Services
{
    public interface IVideoService
    {
        Task<Result<Video>> CreateAsync(CreateVideoRequest request);
        Task<Result> DeleteAsync(DeleteVideoRequest request);
        Task<Result<IEnumerable<Video>>> GetAllAsync(GetAllVideosRequest request);
        Task<Result<Video>> GetByIdAsync(GetByIdVideoRequest request);
        Task<Result> UpdateAsync(UpdateVideoRequest request);
        Task<Result> UploadFileAsync(UploadFileRequest request);
    }
}