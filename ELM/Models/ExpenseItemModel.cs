using System.ComponentModel.DataAnnotations;

namespace ELM.Models;

public class ExpenseItemModel
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Quantity { get; set; }
    [Required]
    public decimal Amount { get; set; }

}