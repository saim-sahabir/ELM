using Autofac;
using ELM.Organization.BusinessObjects;
using ELM.Organization.Services;

namespace ELM.Models;

public class OrganizationSetupModel

{
    private IOrganizationServices _organizationServices;
    private ILifetimeScope _scope;

    public OrganizationSetupModel()
    {
        
    }
    
    public OrganizationSetupModel(IOrganizationServices organizationServices)
    {
        _organizationServices = organizationServices;
    }
    
    public void Resolve(ILifetimeScope scope)
    {
        _scope = scope;
        _organizationServices = _scope.Resolve<IOrganizationServices>();
    }


    public string? Logo { get; set; }
    public string? Name { get; set; }
    public int Id { get; set; }
    
    public  string OwnerId { get; set; }
    
    
    internal void OrganizationLoadData()
    {
        var organizations = _organizationServices.GetOrganizationSetup(Id, OwnerId);
        Id = organizations.Id;
        Name = organizations.Name;
        Logo = organizations.Logo;
        
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