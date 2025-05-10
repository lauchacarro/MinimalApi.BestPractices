using MinimalApi.BestPractices.Application.Models.Results;
using MinimalApi.BestPractices.Application.Models.Sales;

namespace MinimalApi.BestPractices.Application.Services
{
    public interface ISalesService
    {
        Task<Result<CreateSalesResponse>> CreateAsync(CreateSalesRequest request);

    }
}
