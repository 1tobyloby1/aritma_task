using aritma_task.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace aritma_task.Server;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<LoanType> LoanTypes { get; set; }
    public DbSet<Loan> Loans { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoanType>().HasData(
            new LoanType { Id = 1, Name = "Boliglån", InterestRate = 3.5, LoanAmountMin = 30000, LoanAmountMax = 12000000, TermInYearsMin = 1, TermInYearsMax = 30, Strategy = "series_loan"},
            new LoanType { Id = 2, Name = "Billån", InterestRate = 5.0, LoanAmountMin = 5000, LoanAmountMax = 300000, TermInYearsMin = 1, TermInYearsMax = 10, Strategy = "series_loan" }
        );

        modelBuilder.Entity<Loan>().HasData(
            new Loan { Id = 1, LoanTypeId = 1, Amount = 100000, TermInYears = 20, StartDate = new DateTime(2020, 1, 1) },
            new Loan { Id = 2, LoanTypeId = 2, Amount = 20000, TermInYears = 5, StartDate = new DateTime(2021, 6, 15) }
        );
    }
}