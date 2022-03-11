using ELM.Organization.DbContext;
using ELM.Organization.Entities;
using EML.DataAccess;

namespace ELM.Organization.Repositories;

public class OrgMemberRepository : Repository<OrgMembers, int>, IOrgMemberRepository
{
    public OrgMemberRepository(IOrganizationDbContext context) : base((Microsoft.EntityFrameworkCore.DbContext)context)
    {
        
    }
}