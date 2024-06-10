using aritma_task.Server.Dto.Response;
using aritma_task.Server.Models;

namespace aritma_task.Server.Services.Strategies;

public class SeriesLoanCalculationStrategy : ILoanCalculationStrategy
{
    public List<AmortizationDetailResponse> Calculate(Loan loan)
    {
        var monthlyInterestRate = loan.LoanType.InterestRate / 100 / 12;
        var totalPayments = loan.TermInYears * 12;
        var fixedPrincipalPayment = loan.Amount / totalPayments;
        
        var amortizationSchedule = GenerateAmortizationSchedule(
            loan.Amount, monthlyInterestRate, totalPayments, fixedPrincipalPayment, loan.StartDate);
        
        return amortizationSchedule;
    }
    
    private List<AmortizationDetailResponse> GenerateAmortizationSchedule(
        decimal principal, double monthlyInterestRate, int totalPayments, decimal fixedPrincipalPayment, DateTime startDate)
    {
        var schedule = new List<AmortizationDetailResponse>();
        var remainingBalance = principal;

        for (var i = 0; i < totalPayments; i++)
        {
            var interestPayment = remainingBalance * (decimal)monthlyInterestRate;
            remainingBalance -= fixedPrincipalPayment;

            schedule.Add(new AmortizationDetailResponse
            {
                Month = startDate.AddMonths(i+1).Date,
                MonthlyPayment = Math.Round(interestPayment + fixedPrincipalPayment, 2),
                InterestPayment = Math.Round(interestPayment, 2),
                PrincipalPayment = Math.Round(fixedPrincipalPayment, 2),
                RemainingBalance = Math.Round(remainingBalance, 2)
            });
        }

        return schedule;
    }
}