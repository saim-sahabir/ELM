using ELM.Organization.Entities;
using EML.DataAccess;

namespace ELM.Organization.Repositories;

public interface IOrgMemberRepository : IRepository<OrgMembers, int>
{
    List<OrgMembers> GetByOrgId(int orgId);
}