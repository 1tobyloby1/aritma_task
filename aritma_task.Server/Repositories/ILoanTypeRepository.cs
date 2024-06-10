using aritma_task.Server.Models;

namespace aritma_task.Server.Repositories;

public interface ILoanTypeRepository
{
    Task<IEnumerable<LoanType>> GetAllLoanTypes();
    Task<LoanType?> GetLoanTypeById(int id);
}