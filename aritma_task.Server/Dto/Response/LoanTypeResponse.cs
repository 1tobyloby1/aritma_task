namespace aritma_task.Server.Dto.Response;

public class LoanTypeResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double InterestRate { get; set; }
    public decimal LoanAmountMax { get; set; }
    public decimal LoanAmountMin { get; set; }
    public int TermInYearsMax { get; set; }
    public int TermInYearsMin { get; set; }
    public string Strategy { get; set; }
}
