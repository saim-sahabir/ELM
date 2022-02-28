using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ELM.Models;

public class OrganizationModel
{
    
    public int Id { get; set; }
    [Required]
    [Display(Name = "Organization name is required")]
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string? Email { get; set; }
    public string? Logo { get; set; }
    public string? Address { get; set; }
    public int Phone { get; set; }
    public int OwnerId { get; set; }
    public string? Status { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsActive { get; set; }
}