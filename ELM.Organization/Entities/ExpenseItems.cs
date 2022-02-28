using EML.DataAccess;

namespace ELM.Organization.Entities;

public class ExpenseItems: IEntity<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Quantity { get; set; }
    public decimal Amount { get; set; }
  
    public Expenses Expenses { get; set; }
}