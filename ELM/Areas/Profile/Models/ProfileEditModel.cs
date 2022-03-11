using System.ComponentModel.DataAnnotations;
using ELM.Users.Entity;

namespace ELM.Areas.Profile.Models;

public class ProfileEditModel
{
    
    
    public Guid Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    [Required]
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? ProfileImage { get; set; }
    public string? UserName { get; set; }
    [Required]
    public string? DisplayName { get; set; }
    
   
    
}