using ELM.Organization.BusinessObjects;
using ELM.Organization.Entities;

namespace ELM.Organization.Services;

public interface IOrganizationServices
{ 
    int CreateOrganization(SetupOrganaization setupOrganaization);

     Organizations GetOrganizationSetup(int id, string ownerId);

     void LogoUpdate(SetupOrganaization setupOrganaization);
     List<SetupOrganaization> LoadOrgListByOwnerId(string ownerId);
}