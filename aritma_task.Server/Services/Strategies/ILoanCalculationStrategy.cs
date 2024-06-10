using aritma_task.Server.Dto.Response;
using aritma_task.Server.Models;

namespace aritma_task.Server.Services.Strategies;

public interface ILoanCalculationStrategy
{
    List<AmortizationDetailResponse> Calculate(Loan loan);
}