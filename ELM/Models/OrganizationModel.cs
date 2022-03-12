using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Autofac;
using ELM.Organization.BusinessObjects;
using ELM.Organization.Services;

namespace ELM.Models;

public class OrganizationModel
{

    private IOrganizationServices _organizationServices;
    private IOrgMemberServices _memberServices;
    private ILifetimeScope _scope;

    public OrganizationModel()
    {
        
    }
    
    public OrganizationModel(IOrganizationServices organizationServices, IOrgMemberServices memberServices)
    {
        _organizationServices = organizationServices;
        _memberServices = memberServices;
    }
    
    public void Resolve(ILifetimeScope scope)
    {
        _scope = scope;
        _organizationServices = _scope.Resolve<IOrganizationServices>();
        _memberServices = _scope.Resolve<IOrgMemberServices>();
    }
    
    
    public int Id { get; set; }
    [Required]
    [Display(Name = "Organization name is required")]
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string? Email { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    
    public int Phone { get; set; }
    public string? OwnerId { get; set; }
    public string? Logo { get; set; }
    public string? Status { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsActive { get; set; }

    public List<MemberModel>? MemberInfo { get; set; }

    public void GetMemberByOrg(int id)
    {
       var member = _memberServices.GetMemberByOrg(id);
        
        
    }
    
    public void GetOrganization(int id)
    {
      var org =   _organizationServices.GetOrganizations(id);
      Id = org.Id;
      Name = org.Name;
      Address = org.Address;
      Logo = org.Logo;
      Phone = org.Phone;
      OwnerId = org.OwnerId;
      Status = org.Status;
      IsActive = org.IsActive;
      DateTime = org.DateTime;

    }
    
    

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

        var memberData = new Member()
        {
          OrgId = Id,
          UserId = OwnerId,
          Role = "Owner",
          Date = DateTime.Today,
          IsActive = true,
          Status = "Accept"
          
        };
        _memberServices.AddMember(memberData);
        

    }

   
    
    
    
}


