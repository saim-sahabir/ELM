using ELM.Expenses.DbContext;
using ELM.Expenses.Repositories;
using EML.DataAccess;

namespace ELM.Expenses.UnitOfWorks;

public class ExpensesUnitOfWork : UnitOfWork , IExpensesUnitOfWork
{
    public IExpenseRepository Expense { get; private set; }
    
    public ExpensesUnitOfWork(IElmDbContext dbContext , 
        IExpenseRepository expenseRepository) : base((Microsoft.EntityFrameworkCore.DbContext)dbContext)
    {
        Expense = expenseRepository;
    }
}