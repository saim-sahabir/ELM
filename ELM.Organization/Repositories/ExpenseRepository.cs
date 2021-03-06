using ELM.Organization.DbContext;
using ELM.Organization.Entities;
using EML.DataAccess;

namespace ELM.Organization.Repositories;

public class ExpenseRepository : Repository<Expenses, int>, IExpenseRepository
{
    private readonly IOrganizationDbContext _context;
    public ExpenseRepository(IOrganizationDbContext context) : base((Microsoft.EntityFrameworkCore.DbContext)context)
    {
        _context = context;
    }
    
    
}