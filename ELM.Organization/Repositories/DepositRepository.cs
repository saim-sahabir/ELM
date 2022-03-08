using ELM.Organization.DbContext;
using ELM.Organization.Entities;
using ELM.Organization.Services;
using EML.DataAccess;

namespace ELM.Organization.Repositories;

public class DepositRepository : Repository<Deposit , int> , IDepositRepository
{
    public DepositRepository(IOrganizationDbContext context) : base((Microsoft.EntityFrameworkCore.DbContext)context)
    {
        
    }
}