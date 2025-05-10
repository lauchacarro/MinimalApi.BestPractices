using MinimalApi.BestPractices.Application.Models.Results;
using MinimalApi.BestPractices.Application.Models.Sales;

namespace MinimalApi.BestPractices.Application.Services
{
    public class SalesService : ISalesService
    {
        public async Task<Result<CreateSalesResponse>> CreateAsync(CreateSalesRequest request)
        {
            return new CreateSalesResponse();
        }
    }

}
