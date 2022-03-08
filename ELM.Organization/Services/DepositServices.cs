using ELM.Organization.UnitOfWorks;

namespace ELM.Organization.Services;

public class DepositServices : IDepositServices
{
    private readonly IDepositUnitOfWork _depositUnitOfWork;
    public DepositServices(IDepositUnitOfWork depositUnitOfWork)
    {
        _depositUnitOfWork = depositUnitOfWork;

    }
    
    
}