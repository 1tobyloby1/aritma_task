using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aritma_task.Server.Dto.Request;
using aritma_task.Server.Dto.Response;
using aritma_task.Server.Models;
using aritma_task.Server.Repositories;
using aritma_task.Server.Services;
using AutoMapper;
using Moq;

namespace Server.Tests.Services;

public class LoanServiceTests
{
    private readonly Mock<ILoanTypeRepository> _loanTypeRepositoryMock;
    private readonly Mock<ILoanRepository> _loanRepositoryMock;
    private readonly LoanService _loanService;
    private readonly Mock<IMapper> _mapperMock;

    public LoanServiceTests()
    {
        _mapperMock = new Mock<IMapper>();
        _loanTypeRepositoryMock = new Mock<ILoanTypeRepository>();
        _loanRepositoryMock = new Mock<ILoanRepository>();
        _loanService = new LoanService(_loanTypeRepositoryMock.Object, _loanRepositoryMock.Object, _mapperMock.Object);
    }
    
    [Fact]
    public async Task GetAllLoans_ReturnsMappedLoanResponses()
    {
        var loans = new List<Loan> { new Loan { Id = 1, LoanTypeId = 1 } };
        var loanResponses = new List<LoanResponse> { new LoanResponse { Id = 1 } };

        _loanRepositoryMock.Setup(repo => repo.GetAllLoans()).ReturnsAsync(loans);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<LoanResponse>>(loans)).Returns(loanResponses);

        var result = await _loanService.GetAllLoans();

        Assert.Equal(loanResponses, result);
    }
    
    [Fact]
    public async Task GetAllLoanTypes_ReturnsMappedLoanTypeResponses()
    {
        var loanTypes = new List<LoanType> { new LoanType {Id = 1, Strategy = "", LoanAmountMax = 0, LoanAmountMin = 0, TermInYearsMax = 0, TermInYearsMin = 0, Name = "", InterestRate = 0.0 } };
        var loanTypeResponses = new List<LoanTypeResponse> { new LoanTypeResponse { Id = 1, Strategy = "", LoanAmountMax = 0, LoanAmountMin = 0, TermInYearsMax = 0, TermInYearsMin = 0, Name = "", InterestRate = 0.0 } };
        
        _loanTypeRepositoryMock.Setup(repo => repo.GetAllLoanTypes()).ReturnsAsync(loanTypes);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<LoanTypeResponse>>(loanTypes)).Returns(loanTypeResponses);

        var result = await _loanService.GetAllLoanTypes();

        Assert.Equal(loanTypeResponses, result.ToList());
    }
    
    [Fact]
    public async Task CalculateLoan_WithValidRequest_ReturnsCalculatedLoanResponse()
    {
        var loanRequest = new LoanRequest { LoanTypeId = 1, Amount = 2000, TermInYears = 2};
        var loan = new Loan { Id = 1, LoanTypeId = 1, Amount = 2000, TermInYears = 2 };
        var loanType = new LoanType { Id = 1, Strategy = "series_loan" };
        var amortizationDetails = new List<AmortizationDetailResponse>();
        var loanResponse = new LoanResponse { Id = 1, AmortizationSchedule = amortizationDetails };

        _mapperMock.Setup(mapper => mapper.Map<Loan>(loanRequest)).Returns(loan);
        _loanTypeRepositoryMock.Setup(repo => repo.GetLoanTypeById(1)).ReturnsAsync(loanType);
        _mapperMock.Setup(mapper => mapper.Map<LoanResponse>(loan)).Returns(loanResponse);

        var result = await _loanService.CalculateLoan(loanRequest);

        Assert.Equal(loanResponse, result);
    }
    
    [Fact]
    public async Task CalculateLoan_WithInvalidLoanType_ThrowsArgumentException()
    {
        var loanRequest = new LoanRequest { LoanTypeId = 1 };
        var loan = new Loan { Id = 1, LoanTypeId = 1 };

        _mapperMock.Setup(mapper => mapper.Map<Loan>(loanRequest)).Returns(loan);
        _loanTypeRepositoryMock.Setup(repo => repo.GetLoanTypeById(1)).ReturnsAsync((LoanType)null);
        await Assert.ThrowsAsync<ArgumentException>(() => _loanService.CalculateLoan(loanRequest));
    }
    
    [Fact]
    public async Task CalculateLoan_WithInvalidLoanStrategy_ThrowsArgumentException()
    {
        var loanRequest = new LoanRequest { LoanTypeId = 1 };
        var loan = new Loan { Id = 1, LoanTypeId = 1 };
        var loanType = new LoanType { Id = 1, Strategy = "invalid_strategy" };

        _mapperMock.Setup(mapper => mapper.Map<Loan>(loanRequest)).Returns(loan);
        _loanTypeRepositoryMock.Setup(repo => repo.GetLoanTypeById(1)).ReturnsAsync(loanType);

        await Assert.ThrowsAsync<ArgumentException>(() => _loanService.CalculateLoan(loanRequest));
    }
}