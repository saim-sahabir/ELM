using System.ComponentModel.DataAnnotations;
using Autofac;
using ELM.Organization.BusinessObjects;
using ELM.Organization.Services;
using ELM.Users.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELM.Models;

public class OrganizationSetupModel

{
    private IOrganizationServices _organizationServices;
    private ILifetimeScope _scope;
    private IOrgMemberServices _memberServices;

    public OrganizationSetupModel()
    {
        
    }
    
    public OrganizationSetupModel(IOrganizationServices organizationServices, IOrgMemberServices memberServices)
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

    public List<AppUser>? Users { get; set; }
    public string? Logo { get; set; }
    
    public string? Name { get; set; }
    public int Id { get; set; }
    
    public  string? OwnerId { get; set; }
    
    [Required]
    public List<string>? SeEmailLists {get; set; }
    
    public List<Member>? UsersId { get; set; }

    internal void OrganizationLoadData()
    {
        var organizations = _organizationServices.GetOrganizationSetup(Id, OwnerId);
        Id = organizations.Id;
        Name = organizations.Name;
        Logo = organizations.Logo;
        
    }


    public void InviteMember()
    {
        var memberData = new List<Member>();
        foreach (var list in UsersId)
        {
            memberData.Add(new Member()
            {
                OrgId = Id,
                Status = "Pending",
                UserId = list.UserId,
                Date = DateTime.Today,
                IsActive = true,
                Role = "Viewer"
                
            });
            
        }
        
        _memberServices.AddMemberList(memberData);
    }
    
    
    public bool LogoSetup()
    {
        var organizations = new SetupOrganaization()
        {
          Id = Id,
          Logo = Logo
        };
        
        _organizationServices.LogoUpdate(organizations);
        
        return true;
    }
    
}