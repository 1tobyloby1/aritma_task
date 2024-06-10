using System.ComponentModel.DataAnnotations;

namespace aritma_task.Server.Dto.Request;

public class LoanRequest
{
    public int LoanTypeId { get; set; }
    public decimal Amount { get; set; }
    public int TermInYears { get; set; }
}