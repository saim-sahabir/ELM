using ELM.Expenses.Entities;
using EML.DataAccess;

namespace ELM.Expenses.Repositories;

public interface IExpenseRepository : IRepository<Expense, int>
{
    
}