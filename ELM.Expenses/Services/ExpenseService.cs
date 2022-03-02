using ELM.Expenses.BusinessObjects;
using ELM.Expenses.UnitOfWorks;


namespace ELM.Expenses.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesUnitOfWork _expensesUnitOfWork;
    public ExpenseService(IExpensesUnitOfWork expensesUnitOfWork)
    {
        _expensesUnitOfWork = expensesUnitOfWork;
    }
    public void CreateExpense(Expense expense)
    {
        var entity = new Entities.Expense
        {
          Id  = expense.Id,
          Name = expense.Name,
          Amount = expense.Amount,
          Date = expense.Date,
          Description = expense.Description,
          Category = expense.Category
        };
        _expensesUnitOfWork.Expense.Add(entity);
        _expensesUnitOfWork.Save();
        
    } 
    
    
}