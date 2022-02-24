namespace ELM.Organization.Entities;

public class OrgMembers
{
   public int Id { get; set; }
   public int UserId { get; set; }
   public int OrgId { get; set; }
   public string? Status { get; set; }
   public DateTime Date { get; set; }
   public bool IsActive { get; set; }
}