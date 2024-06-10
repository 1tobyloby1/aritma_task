using aritma_task.Server.Dto.Request;
using aritma_task.Server.Dto.Response;
using aritma_task.Server.Models;
using aritma_task.Server.Repositories;
using aritma_task.Server.Services.Strategies;
using AutoMapper;

namespace aritma_task.Server.Services;

public class LoanService(ILoanTypeRepository loanTypeRepository, ILoanRepository loanRepository, IMapper mapper)
    : ILoanService
{
    private readonly Dictionary<string, ILoanCalculationStrategy> _strategies = new()
    {
        { "series_loan", new SeriesLoanCalculationStrategy() },
    };

    public async Task<IEnumerable<LoanResponse>> GetAllLoans()
    {
        var loans = await loanRepository.GetAllLoans();
        return mapper.Map<IEnumerable<LoanResponse>>(loans);
        /*var myList = new List<LoanResponse>();

        foreach (var loan in loans)
        {
            var strategy = _strategies[loan.LoanType.Strategy];
            var amortizationDetails = strategy.Calculate(loan);

            var response = mapper.Map<LoanResponse>(loan);
            response.AmortizationSchedule = amortizationDetails;
            myList.Add(response);
        }
        return myList;
        */
    }
    
    public async Task<IEnumerable<LoanTypeResponse>> GetAllLoanTypes()
    {
        var loanTypes = await loanTypeRepository.GetAllLoanTypes();
        var loanTypesResponse = mapper.Map<IEnumerable<LoanTypeResponse>>(loanTypes);
        return loanTypesResponse;
    }

    public async Task<IEnumerable<LoanResponse>> GetAllLoansByType(int loanType)
    {
        var loans = await loanRepository.GetAllLoansByType(loanType);
        return mapper.Map<IEnumerable<LoanResponse>>(loans);
    }

    public async Task<LoanResponse> CalculateLoan(LoanRequest loanRequest)
    {
        var loan = mapper.Map<Loan>(loanRequest);
        
        var loanType = await loanTypeRepository.GetLoanTypeById(loan.LoanTypeId);
        if (loanType == null)
        {
            throw new ArgumentException("Invalid Loan Type");
        }

        if (!_strategies.ContainsKey(loanType.Strategy))
        {
            throw new ArgumentException("Invalid Loan Strategy");
        }
        
        loan.LoanType = loanType;
        
        var strategy = _strategies[loanType.Strategy];
        var amortizationDetails = strategy.Calculate(loan);

        var response = mapper.Map<LoanResponse>(loan);
        response.AmortizationSchedule = amortizationDetails;
        
        return response;
    }
}