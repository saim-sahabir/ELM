using ELM.Organization.Repositories;
using EML.DataAccess;

namespace ELM.Organization.UnitOfWorks;

public interface IDepositUnitOfWork : IUnitOfWork
{
    IDepositRepository Deposit { get; }
}