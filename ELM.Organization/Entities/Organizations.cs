using EML.DataAccess;

namespace ELM.Organization.Entities;

public class Organizations: IEntity<int>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public string? Email { get; set; }
    
    public string? Logo { get; set; }
    public string? Address { get; set; }
    public int Phone { get; set; }
    public string? OwnerId { get; set; }
    public string? Status { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsActive { get; set; }
    public IList<OrgMembers> MembersList { get; set; }
    public IList<Expenses> ExpensesList { get; set; }
    public IList<Deposit> Deposits { get; set; }
}