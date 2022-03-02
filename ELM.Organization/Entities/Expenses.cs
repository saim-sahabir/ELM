using EML.DataAccess;

namespace ELM.Organization.Entities;

public class Expenses : IEntity<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Category { get; set; }
    public string? Status { get; set; }
    public string? OwnerId { get; set; }
    public int OrgId { get; set; }
    public bool IsActive { get; set; }
    public IList<ExpenseItems> ItemsList { get; set; }
    public Organizations Organizations { get; set; }
}