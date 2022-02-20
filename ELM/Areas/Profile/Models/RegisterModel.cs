using System.ComponentModel.DataAnnotations;
using Autofac;
using ELM.Users.BusinessObjects;
using ELM.Users.Services;

namespace ELM.Areas.Profile.Models;

public class RegisterModel
{
    private  MemberService _memberService;
    private ILifetimeScope? _scope;

    [Required, MaxLength(100)] 
    [Display(Name = "Full Name")]
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

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; }

   
    //this constructor is not used

    public RegisterModel()
    {
        
    }
    
    public RegisterModel(MemberService memberService)
    {
        _memberService = memberService;
    }
     public void Resolve(ILifetimeScope scope)
     {
         _scope = scope;
         _memberService = _scope.Resolve<MemberService>();
     }
  
    internal void RegisterUser()
    {
        var user = new UserRegister()
        {
            DisplayName = DisplayName,
            Email = Email,
            UserName = Email,
            Password = Password
        };

        _memberService.CreateUser(user);
    }

}