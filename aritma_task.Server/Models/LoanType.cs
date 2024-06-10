using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aritma_task.Server.Models;

public class LoanType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public double InterestRate { get; set; }
    
    public decimal LoanAmountMax { get; set; }
    
    public decimal LoanAmountMin { get; set; }
    
    public int TermInYearsMax { get; set; }
    
    public int TermInYearsMin { get; set; }
    
    public string Strategy { get; set; }
}