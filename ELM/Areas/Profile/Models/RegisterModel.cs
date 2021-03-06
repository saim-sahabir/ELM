using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace ELM.Areas.Profile.Models;

public class RegisterModel
{
    
    [Required]
    [Display(Name = "Give Your User Name")]
    public string? DisplayName { get; set; }
            
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string? Email { get; set; }
            
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string? Password { get; set; }
            
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    
    public string? ConfirmPassword { get; set; }
    
    public string? ReturnUrl { get; set; }
        
    public IList<AuthenticationScheme>? ExternalLogins { get; set; }
    
}