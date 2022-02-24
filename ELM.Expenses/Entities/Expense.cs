using EML.DataAccess;

namespace ELM.Expenses.Entities;

public class Expense : IEntity<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Category { get; set; }
    public string? Status { get; set; }
    public bool IsActive { get; set; }
}