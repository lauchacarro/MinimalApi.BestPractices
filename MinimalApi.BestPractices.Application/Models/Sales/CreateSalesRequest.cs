using MinimalApi.BestPractices.Application.Interfaces;

namespace MinimalApi.BestPractices.Application.Models.Sales
{
    public record CreateSalesRequest(int ProductId, int Quantity, decimal Price) : IUserId
    {
        public Guid UserId { get; set; }
    }

    public record CreateSalesResponse;
}
