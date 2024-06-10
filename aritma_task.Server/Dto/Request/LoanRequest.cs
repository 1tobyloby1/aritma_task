using System.ComponentModel.DataAnnotations;

namespace aritma_task.Server.Dto.Request;

public class LoanRequest
{
    [Required(ErrorMessage = "LoanTypeId is required.")]
    public int LoanTypeId { get; set; }
    
    [Required(ErrorMessage = "Amount is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public decimal Amount { get; set; }
    
    [Required(ErrorMessage = "TermInYears is required.")]
    [Range(1, 30, ErrorMessage = "Term must be between 1 and 30 years.")]
    public int TermInYears { get; set; }
}