using ELM.Organization.DbContext;
using ELM.Organization.Repositories;
using EML.DataAccess;

namespace ELM.Organization.UnitOfWorks;

public class OrgMemberUnitOfWork : UnitOfWork, IOrgMemberUnitOfWork
{
    public IOrgMemberRepository OrgMember { get; private set; }
    public OrgMemberUnitOfWork(IOrganizationDbContext dbContext,
        IOrgMemberRepository orgMemberRepository): base((Microsoft.EntityFrameworkCore.DbContext) dbContext)
    {
        OrgMember = orgMemberRepository;
    }
}