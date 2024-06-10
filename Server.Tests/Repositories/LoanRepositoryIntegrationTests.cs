using System;
using System.Linq;
using System.Threading.Tasks;
using aritma_task.Server;
using aritma_task.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Server.Tests.Repositories;

public class LoanRepositoryIntegrationTests : IDisposable
{
    private readonly LoanRepository _loanRepository;
    private readonly ApplicationDbContext _context;
    
    public LoanRepositoryIntegrationTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new ApplicationDbContext(options);
        _context.Database.EnsureCreated();
        
        _loanRepository = new LoanRepository(_context);
    }

    [Fact]
    public async Task GetAllLoans_ReturnsAllLoans()
    {
        var loans = await _loanRepository.GetAllLoans();
        Assert.Equal(2, loans.Count());
    }
    
    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}