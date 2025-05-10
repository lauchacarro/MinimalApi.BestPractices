using MinimalApi.BestPractices.Application.Models.Results;
using MinimalApi.BestPractices.Application.Models.Videos;

namespace MinimalApi.BestPractices.Application.Services
{
    internal class VideoService : IVideoService
    {
        private readonly List<Video> _videos = new();

        public async Task<Result<Video>> CreateAsync(CreateVideoRequest request)
        {
            Video video = new Video
            {
                Title = request.Title,
                Description = request.Description,
                Url = request.Url
            };

            video.Id = Guid.NewGuid();
            _videos.Add(video);
            return video;
        }

        public async Task<Result<Video>> GetByIdAsync(GetByIdVideoRequest request)
        {
            var video = _videos.FirstOrDefault(v => v.Id == request.Id);

            if (video is null)
                return "Video not found.";

            return video;
        }

        public async Task<Result<IEnumerable<Video>>> GetAllAsync(GetAllVideosRequest request)
        {
            return _videos;
        }

        public async Task<Result> UpdateAsync(UpdateVideoRequest request)
        {
            var video = _videos.FirstOrDefault(v => v.Id == request.Id);
            if (video is null)
                return "Video not found.";

            video.Title = request.Title;
            video.Description = request.Description;
            video.Url = request.Url;
            return true;
        }

        public async Task<Result> DeleteAsync(DeleteVideoRequest request)
        {
            var video = _videos.FirstOrDefault(v => v.Id == request.Id);
            if (video == null) return false;

            _videos.Remove(video);
            return true;
        }

        public Task<Result> UploadFileAsync(UploadFileRequest request)
        {
            throw new NotImplementedException();
        }
    }

    public class Video
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
