
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;
using Autofac;
using ELM.Areas.Identity.Data;
using ELM.Organization.BusinessObjects;
using ELM.Expenses.Services;
using ELM.Organization.Services;
using Microsoft.AspNetCore.Identity;

namespace ELM.Models;

public class ExpenseModel
{

    private  ILifetimeScope? _scope;
    private IExpanseService _expanseService;

    public ExpenseModel()
    {
        
    }

    public ExpenseModel(IExpanseService expanseService)
    {
        
        _expanseService = expanseService;
    }
    public void Resolve(ILifetimeScope scope)
    {
        _scope = scope;
       _expanseService = _scope.Resolve<IExpanseService>();

    }
    
    
    public int Id { get; set; }
    public int LastId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Category { get; set; }
    public string? Status { get; set; }
    public string? OwnerId { get; set; }
    public int OrgId { get; set; }
    public bool IsActive { get; set; }
    public string? ItemsList { get; set; }
   
    public List<ExpenseItemModel>? ExpenseItem { get; set; }


    public void AddExpense()
    {
        var expanses = new Expanse()
        {
          Id = Id,
          Name = Name,
          Amount = Amount,
          Date = Date,
          Description = Description,
          Category = Category,
          Status = Status,
          OrgId = OrgId,
          OwnerId = OwnerId,
          IsActive = IsActive,
          
        };

        var expenseItem = new List<ExpanseItems>();

        foreach (var item in ExpenseItem)
        {
            expenseItem.Add(new ExpanseItems 
            {
                Id = item.Id,
                Name = item.Name,
                Amount = item.Amount,
                Quantity = item.Quantity
            });
        } 
        
        LastId =  _expanseService.AddExpanseWithItem(expanses, expenseItem);
      
    }

    public void GetAllExpenseByOrgId(int id)
    {
        _expanseService.GetAllExpense(id);

        

    }
     
}
