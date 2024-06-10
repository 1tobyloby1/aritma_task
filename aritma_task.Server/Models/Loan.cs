using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aritma_task.Server.Models;

public class Loan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int LoanTypeId { get; set; }

    [ForeignKey("LoanTypeId")]
    public virtual LoanType LoanType { get; set; }

    public decimal Amount { get; set; }

    public int TermInYears { get; set; }

    public DateTime StartDate { get; set; }
}