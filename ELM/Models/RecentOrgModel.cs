using Autofac;
using ELM.Organization.BusinessObjects;
using ELM.Organization.Services;

namespace ELM.Models;

public class RecentOrgModel
{
    private IOrganizationServices _organizationServices;
    private ILifetimeScope _scope;
    private IOrgMemberServices _memberServices;

    public RecentOrgModel()
    {
        
    }
    
    public RecentOrgModel(IOrganizationServices organizationServices, IOrgMemberServices orgMemberServices)
    {
        _organizationServices = organizationServices;
        _memberServices = orgMemberServices;

    }
    
    public void Resolve(ILifetimeScope scope)
    {
        _scope = scope;
        _organizationServices = _scope.Resolve<IOrganizationServices>();
    }

    public MemberModel memberCount { get; set; }
   public List<SetupOrganaization> OrgList { get; private set; }
   
   

   public void GetOrgByOwner(string ownerId)
   {
       
       OrgList =  _organizationServices.LoadOrgListByOwnerId(ownerId);
   }

}