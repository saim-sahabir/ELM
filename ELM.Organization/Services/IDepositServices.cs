using ELM.Organization.BusinessObjects;

namespace ELM.Organization.Services;

public interface IDepositServices
{
    int AddDeposit(Deposits deposits);
}