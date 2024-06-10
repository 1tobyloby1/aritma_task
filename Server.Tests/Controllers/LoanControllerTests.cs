using System.Collections.Generic;
using System.Threading.Tasks;
using aritma_task.Server.Controllers;
using aritma_task.Server.Dto.Response;
using aritma_task.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Server.Tests.Controllers;

public class LoanControllerTests
{    
    [Fact]
    public async Task GetAllLoans_ShouldReturnListOfLoans()
    {
        var mockService = new Mock<ILoanService>();
        mockService.Setup(service => service.GetAllLoans()).ReturnsAsync(GetSampleLoans());

        var controller = new LoanController(mockService.Object);
        var result = await controller.GetAllLoans();

        var actionResult = Assert.IsType<ActionResult<IEnumerable<LoanResponse>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<List<LoanResponse>>(okResult.Value);
        
        Assert.Equal(3, returnValue.Count);
    }
    
    private List<LoanResponse> GetSampleLoans()
    {
        return
        [
            new LoanResponse { Id = 1, Amount = 1000, TermInYears = 5 },
            new LoanResponse { Id = 2, Amount = 2000, TermInYears = 2 },
            new LoanResponse { Id = 3, Amount = 2000, TermInYears = 2 }
        ];
    }
}