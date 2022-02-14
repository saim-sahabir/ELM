using ELM.Expenses.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELM.Expenses.DbContext;

public interface IElmDbContext
{
    DbSet<Expense> Expenses { get; set; } 
    DbSet<ExpenseItem> ExpenseItems { get; set; }
}