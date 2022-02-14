using ELM.Expenses.DbContext;
using ELM.Expenses.Entities;
using EML.DataAccess;
namespace ELM.Expenses.Repositories;

public class ExpenseRepository: Repository<Expense, int> , IExpenseRepository
{
  
    public ExpenseRepository(IElmDbContext context) : base((Microsoft.EntityFrameworkCore.DbContext)context)
    {
        
    }
    
}