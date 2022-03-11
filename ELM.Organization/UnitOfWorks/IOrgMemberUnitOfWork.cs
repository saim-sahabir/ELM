using ELM.Organization.Repositories;
using EML.DataAccess;

namespace ELM.Organization.UnitOfWorks;

public interface IOrgMemberUnitOfWork : IUnitOfWork
{
    IOrgMemberRepository OrgMember { get; }
}