using aritma_task.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace aritma_task.Server.Repositories;

public class LoanTypeRepository(ApplicationDbContext context) : ILoanTypeRepository
{
    public async Task<IEnumerable<LoanType>> GetAllLoanTypes()
    {
        return await context.LoanTypes.ToListAsync();
    }
    
    public async Task<LoanType?> GetLoanTypeById(int id)
    {
        return await context.LoanTypes.FindAsync(id);
    }
}