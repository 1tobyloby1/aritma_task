namespace aritma_task.Server.Dto.Response;

public class AmortizationDetailResponse
{
    public DateTime Month { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal InterestPayment { get; set; }
    public decimal PrincipalPayment { get; set; }
    public decimal RemainingBalance { get; set; }
}