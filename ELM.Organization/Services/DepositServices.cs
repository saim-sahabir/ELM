using ELM.Organization.BusinessObjects;
using ELM.Organization.Entities;
using ELM.Organization.UnitOfWorks;

namespace ELM.Organization.Services;

public class DepositServices : IDepositServices
{
    private readonly IDepositUnitOfWork _depositUnitOfWork;
    public DepositServices(IDepositUnitOfWork depositUnitOfWork)
    {
        _depositUnitOfWork = depositUnitOfWork;

    }
    
    public int AddDeposit(Deposits deposits)
    {
        var deposit = new Deposit()
        {
            Id = deposits.Id,
            MemberName = deposits.MemberName,
            Amount = deposits.Amount,
            Status = deposits.Status,
            Description = deposits.Description,
            PaymentMethod = deposits.PaymentMethod,
            OrgId = deposits.OrgId,
            Date = deposits.Date,
            Refarence = deposits.Refarence,
            IsActive = deposits.IsActive


        };
         _depositUnitOfWork.Deposit.Add(deposit);
         _depositUnitOfWork.Save();
        return deposit.Id;
    }
    
    
}