using ELM.Organization.BusinessObjects;
using ELM.Organization.DbContext;
using ELM.Organization.Entities;
using EML.DataAccess;

namespace ELM.Organization.Repositories;

public class OrgMemberRepository : Repository<OrgMembers, int>, IOrgMemberRepository
{
    private readonly IOrganizationDbContext _context;
    public OrgMemberRepository(IOrganizationDbContext context) : base((Microsoft.EntityFrameworkCore.DbContext)context)
    {
        _context = context;
    }
    
    public List<OrgMembers> GetByOrgId(int orgId)
    {
        return _context.OrgMembers.Where(x => x.OrgId == orgId).ToList();
    }
    
}