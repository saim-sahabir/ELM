using ELM.Organization.Entities;
using EML.DataAccess;

namespace ELM.Organization.Repositories;

public interface IOrganizationRepository : IRepository<Organizations, int>
{
    Organizations GetOrganizationsBySetup(int id, string userId);
}