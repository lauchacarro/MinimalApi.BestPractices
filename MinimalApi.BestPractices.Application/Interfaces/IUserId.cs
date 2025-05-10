namespace MinimalApi.BestPractices.Application.Interfaces
{
    public interface IUserId
    {
        public Guid UserId { get; set; }
    }

    public interface IRole
    {
        public IEnumerable<string> Roles { get; set; }
    }
}
