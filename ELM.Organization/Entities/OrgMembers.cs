using EML.DataAccess;

namespace ELM.Organization.Entities;

public class OrgMembers : IEntity<int>
{
   public int Id { get; set; }
   public string? UserId { get; set; }
   public int OrgId { get; set; }
   public string? Status { get; set; }
   public DateTime Date { get; set; }
   public string? Role { get; set; }
   public bool IsActive { get; set; }
   //public Organizations Organizations { get; set; }
}