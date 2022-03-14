using ELM.Organization.BusinessObjects;
using ELM.Organization.Entities;
using ELM.Organization.UnitOfWorks;

namespace ELM.Organization.Services;

public class ExpanseService : IExpanseService
{
    private readonly IOrganizationUnitOfWork _organizationUnitOfWork;

    public ExpanseService(IOrganizationUnitOfWork organizationUnitOfWork)
    {
        _organizationUnitOfWork = organizationUnitOfWork;
    }

    public int AddExpanseWithItem(Expanse expanse, List<ExpanseItems> expanseItemsList)
    {
        var expenseData = new Expenses
        { 
            Name = expanse.Name,
            Category = expanse.Category,
            Amount = expanse.Amount,
            OrgId = expanse.OrgId,
            OwnerId = expanse.OwnerId,
            Description = expanse.Description,
            Status = expanse.Status,
            Date = expanse.Date,
            IsActive = expanse.IsActive
        };
          _organizationUnitOfWork.Expense.Add(expenseData);
          _organizationUnitOfWork.Save();
          var expenseId =  expenseData.Id;

        var expenseItemData = new List<ExpenseItems>();

        foreach (var item in expanseItemsList)
        {
            expenseItemData.Add(new ExpenseItems()
            {
                Name = item.Name,
                Amount = item.Amount,
                Quantity = item.Quantity,
                ExpensesId = expenseId
            });
        }

        foreach (var itemData in expenseItemData)
        {
            _organizationUnitOfWork.ExpenseItem.Add(itemData);
        } 
        
        _organizationUnitOfWork.Save();
        
        return expenseId;
    }

     public List<Expanse> GetAllExpense(int orgId)
     {
        
         var result =   _organizationUnitOfWork.Expense.Get(x => x.OrgId.Equals(orgId), x => x.OrderByDescending(x=> x.Id), string.Empty,  false);

         var expenseData = new List<Expanse>();

         foreach (var item in result)
         {
           expenseData.Add(new Expanse()
           {
               Id = item.Id,
               Name = item.Name,
               Description = item.Description,
               Status = item.Status,
               OrgId = item.OrgId,
               Amount = item.Amount,
               IsActive = item.IsActive,
               Category = item.Category,
               OwnerId = item.OwnerId,
               Date = item.Date
                   
           });  
         }

         return expenseData;
     }

     public List<ExpanseItems> GetExpenseItem(int expenseId)
     {
         var expenseItemData = new List<ExpanseItems>();
         var expenseItem = _organizationUnitOfWork.ExpenseItem.Get(x => x.ExpensesId.Equals(expenseId), null, string.Empty, false);
         foreach (var item in expenseItem)
         {
             expenseItemData.Add(new ExpanseItems()
             {
                 Id = item.Id,
                 Name = item.Name,
                 Quantity = item.Quantity,
                 Amount = item.Amount
             });
         }

         return expenseItemData;
     }

     public Expanse GetExpanseById(int id)
     {
         var expense = _organizationUnitOfWork.Expense.GetById(id);
         var expenseData = new Expanse()
         {
          Id = expense.Id,
          Name = expense.Name,
          Date = expense.Date,
          Amount = expense.Amount,
          OrgId = expense.OrgId,
          Category = expense.Category,
          Description = expense.Description,
         };

         return expenseData;
     }
}