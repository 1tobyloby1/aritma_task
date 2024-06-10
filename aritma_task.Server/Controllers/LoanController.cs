using aritma_task.Server.Dto.Request;
using aritma_task.Server.Dto.Response;
using aritma_task.Server.Models;
using aritma_task.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace aritma_task.Server.Controllers;

[ApiController]
[Route("api/loans")]
public class LoanController(ILoanService loanService) : ControllerBase
{
    [HttpGet("types")]
    public async Task<ActionResult<IEnumerable<LoanTypeResponse>>> GetAllLoanTypes()
    {
        var types = await loanService.GetAllLoanTypes();
        return Ok(types);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanResponse>>> GetAllLoans([FromQuery] int? loanType)
    {
        IEnumerable<LoanResponse> loans;
        if (loanType.HasValue)
        {
            loans = await loanService.GetAllLoansByType(loanType.Value);
        }
        else
        {
            loans = await loanService.GetAllLoans();
        }
        
        return Ok(loans);
    }
    
    [HttpPost]
    public async Task<ActionResult<LoanResponse>> CalculateLoan([FromBody] LoanRequest loanRequest)
    {
        if (!ModelState.IsValid)
        {
            var error = ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage;
            throw new ArgumentException(error);
        }
        
        var loan = await loanService.CalculateLoan(loanRequest);
        return Ok(loan);
    }
}