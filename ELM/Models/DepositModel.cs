using System.ComponentModel.DataAnnotations;

namespace ELM.Models;

public class DepositModel
{
    public int Id { get; set; }
    [Required]
    public string? MemberName { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public string? Refarence { get; set; }
    [Required]
    public string? PaymentMethod { get; set; }
    [Required]
    public string? Description { get; set; }
    
    public string? Status { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public bool IsActive { get; set; }
    [Required]
    public int OrgId { get; set; }
}