using ELM.Organization.DbContext;
using ELM.Organization.Entities;
using EML.DataAccess;

namespace ELM.Organization.Repositories;

public class ExpenseItemRepository : Repository<ExpenseItems, int>, IExpenseItemRepository
{
    private readonly IOrganizationDbContext _context;
    public ExpenseItemRepository(IOrganizationDbContext context) : base((Microsoft.EntityFrameworkCore.DbContext)context)
    {
        _context = context;
    }
}