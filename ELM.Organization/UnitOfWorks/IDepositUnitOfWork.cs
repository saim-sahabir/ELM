using ELM.Organization.Repositories;

namespace ELM.Organization.UnitOfWorks;

public interface IDepositUnitOfWork
{
    IDepositRepository Deposit { get; }
}