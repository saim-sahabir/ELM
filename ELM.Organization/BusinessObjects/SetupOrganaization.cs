namespace ELM.Organization.BusinessObjects;

public class SetupOrganaization
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public int Phone { get; set; }
    public string? OwnerId { get; set; }
    public string? Status { get; set; }
    public string? Logo { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsActive { get; set; }
}