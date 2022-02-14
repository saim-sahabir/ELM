using ELM.Expenses.Repositories;
using EML.DataAccess;

namespace ELM.Expenses.UnitOfWorks;

public interface IExpensesUnitOfWork : IUnitOfWork
{
    IExpenseRepository Expense { get;  }
}
