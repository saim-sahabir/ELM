namespace ELM.Models;

public class DepositModel
{
    public int Id { get; set; }
    public string? MemberName { get; set; }
    public decimal Amount { get; set; }
    public string? Refarence { get; set; }
    public string? PaymentMethod { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public DateTime Date { get; set; }
    public bool IsActive { get; set; }
    public int OrgId { get; set; }
}