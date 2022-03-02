using ELM.Organization.BusinessObjects;
using ELM.Organization.Entities;
using ELM.Organization.UnitOfWorks;

namespace ELM.Organization.Services;

public class OrganizationService: IOrganizationServices
{
    private readonly IOrganizationUnitOfWork _organizationUnitOfWork;
    public OrganizationService(IOrganizationUnitOfWork organizationUnitOfWork)
    {
        _organizationUnitOfWork = organizationUnitOfWork;
    }

    public int CreateOrganization(SetupOrganaization setupOrganaization)
    {
        var organizationData = new Organizations()
        {
           Id = setupOrganaization.Id,
           Name = setupOrganaization.Name,
           OwnerId = setupOrganaization.OwnerId,
           Email = setupOrganaization.Email,
           Phone = setupOrganaization.Phone,
           Address = setupOrganaization.Address,
           Status = setupOrganaization.Status,
           IsActive = setupOrganaization.IsActive,
           DateTime = setupOrganaization.DateTime
           
        };
      _organizationUnitOfWork.Organization.Add(organizationData);
      _organizationUnitOfWork.Save();
      return organizationData.Id;
    }
    
    
    
    public Organizations GetOrganizationSetup(int id, string ownerId)
    {
        var organizationsEntity = _organizationUnitOfWork.Organization.GetOrganizationsBySetup(id, ownerId);
        var organizations = new Organizations();
        organizations.Id = organizationsEntity.Id;
        organizations.Name = organizationsEntity.Name;
        organizations.Logo = organizationsEntity.Logo;
        
        return organizations;
    }

      public void LogoUpdate(SetupOrganaization setupOrganaization)
      {
          var organizationsEntity = _organizationUnitOfWork.Organization.GetById(setupOrganaization.Id);
             organizationsEntity.Logo = setupOrganaization.Logo;
             
          _organizationUnitOfWork.Save();

      }
    
}