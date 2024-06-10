namespace aritma_task.Server.Dto.Response;

public class LoanResponse
{
    public int Id { get; set; }
    public LoanTypeResponse LoanType { get; set; }
    public decimal Amount { get; set; }
    public int TermInYears { get; set; }
    public List<AmortizationDetailResponse> AmortizationSchedule { get; set; }
}