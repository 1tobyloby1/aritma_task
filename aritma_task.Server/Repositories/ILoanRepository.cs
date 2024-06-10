using aritma_task.Server.Models;

namespace aritma_task.Server.Repositories;

public interface ILoanRepository
{
    Task<IEnumerable<Loan>> GetAllLoans();
    Task<IEnumerable<Loan>> GetAllLoansByType(int loanType);
}