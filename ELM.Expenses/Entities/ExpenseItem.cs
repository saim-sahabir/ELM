using EML.DataAccess;

namespace ELM.Expenses.Entities;

public class ExpenseItem : IEntity<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Quantity { get; set; }
    public decimal Amount { get; set; }
}