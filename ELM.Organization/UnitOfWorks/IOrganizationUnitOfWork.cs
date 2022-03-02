using ELM.Organization.Repositories;
using EML.DataAccess;

namespace ELM.Organization.UnitOfWorks;

public interface IOrganizationUnitOfWork : IUnitOfWork
{
    IOrganizationRepository Organization { get;  }
}