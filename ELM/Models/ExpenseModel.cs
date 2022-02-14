
using ELM.Expenses.BusinessObjects;
using ELM.Expenses.Services;

namespace ELM.Models;

public class ExpenseModel
{
    private readonly IExpenseService _expenseService;
    
    public ExpenseModel(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }


    internal void CreateExpense(string Name, decimal Amount)
    {
        var expense = new Expense
        {
            Name = Name,
            Amount = Amount 
        };
        
        _expenseService.CreateExpense(expense);
    }
    

}