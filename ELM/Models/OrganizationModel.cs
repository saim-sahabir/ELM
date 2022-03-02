using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Autofac;
using ELM.Organization.BusinessObjects;
using ELM.Organization.Services;

namespace ELM.Models;

public class OrganizationModel
{

    private IOrganizationServices _organizationServices;
    private ILifetimeScope _scope;

    public OrganizationModel()
    {
        
    }
    
    public OrganizationModel(IOrganizationServices organizationServices)
    {
        _organizationServices = organizationServices;
    }
    
    public void Resolve(ILifetimeScope scope)
    {
        _scope = scope;
        _organizationServices = _scope.Resolve<IOrganizationServices>();
    }
    
    
    public int Id { get; set; }
    [Required]
    [Display(Name = "Organization name is required")]
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string? Email { get; set; }
    public string? Address { get; set; }
    public int Phone { get; set; }
    public string? OwnerId { get; set; }
    public string? Status { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsActive { get; set; }
    
   

    

    public void  CreateOrganizaton()
    {
        var organizationData = new SetupOrganaization()
        {
             Name = Name,
             Email = Email,
             Phone = Phone,
             Address = Address,
             IsActive = true,
             OwnerId = OwnerId,
             DateTime = DateTime.Today,
             Status = "Live"
             
        };
        
        Id = _organizationServices.CreateOrganization(organizationData);
         

    }

   
    
    
    
}


