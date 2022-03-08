using ELM.Organization.DbContext;
using ELM.Organization.Repositories;
using EML.DataAccess;

namespace ELM.Organization.UnitOfWorks;

public class DepositUnitOfWork : UnitOfWork, IDepositUnitOfWork
{
    public IDepositRepository Deposit { get; private set; }
    
    public DepositUnitOfWork(IOrganizationDbContext dbContext , 
        IDepositRepository depositRepository) : base((Microsoft.EntityFrameworkCore.DbContext)dbContext)
    {
        Deposit = depositRepository;
    }
}