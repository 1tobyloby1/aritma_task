using aritma_task.Server.Dto.Request;
using aritma_task.Server.Dto.Response;
using aritma_task.Server.Models;

namespace aritma_task.Server.Services;

public interface ILoanService
{
    Task<IEnumerable<LoanResponse>> GetAllLoans();
    Task<IEnumerable<LoanTypeResponse>> GetAllLoanTypes();
    Task<IEnumerable<LoanResponse>> GetAllLoansByType(int loanType);
    Task<LoanResponse> CalculateLoan(LoanRequest loan);
}