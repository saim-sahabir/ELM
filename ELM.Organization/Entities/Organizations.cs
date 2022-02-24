namespace ELM.Organization.Entities;

public class Organizations
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Logo { get; set; }
    public string? Address { get; set; }
    public int Phone { get; set; }
    public int OwnerId { get; set; }
    public string? Status { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsActive { get; set; }
      
}