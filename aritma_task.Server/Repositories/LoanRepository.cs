using aritma_task.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace aritma_task.Server.Repositories;

public class LoanRepository(ApplicationDbContext context) : ILoanRepository
{
    public async Task<IEnumerable<Loan>> GetAllLoans()
    {
        return await context.Loans.Include(l => l.LoanType).ToListAsync();
    }
    
    public async Task<IEnumerable<Loan>> GetAllLoansByType(int loanType)
    {
        return await context.Loans
            .Include(l => l.LoanType)
            .Where(l => l.LoanTypeId == loanType)
            .ToListAsync();
    }
}