using Autofac;
using ELM.Organization.Services;

namespace ELM.Models;

public class ExpensesViewModel
{
    private  ILifetimeScope? _scope;
    private IExpanseService _expanseService;
    private IOrganizationServices _organizationServices;

    public ExpensesViewModel()
    {
        
    }

    public ExpensesViewModel(IExpanseService expanseService, IOrganizationServices organizationServices)
    {
        
        _expanseService = expanseService;
        _organizationServices = organizationServices;
    }
    public void Resolve(ILifetimeScope scope)
    {
        _scope = scope;
        _expanseService = _scope.Resolve<IExpanseService>();
        _organizationServices = _scope.Resolve<IOrganizationServices>();

    }
    
    public int Id { get; set; }
    public string? OwnerId { get; set; }
    public string? ExpenseName { get; set; }
    public string? OrgName { get; set; }
    public string? OrgLogo { get; set; }
    public string? OrgAddress { get; set; }
    
    public string? OrgEmail { get; set; }
    public string? ExpensePerson { get; set; }
    public string? ExpensePersonEmail { get; set; }
    public int OrgPhone { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public List<ExpenseItemModel>? ExpenseItem { get; set; }

    public void LoadData()
    {
        var expense = _expanseService.GetExpanseById(Id);
        Id = expense.Id;
        ExpenseName = expense.Name;
        Amount = expense.Amount;
        Date = expense.Date;
        Description = expense.Description;
        OwnerId = expense.OwnerId;
        var expanseItem = _expanseService.GetExpenseItem(Id);
        var expenseItemData = new List<ExpenseItemModel>();
        foreach (var item in expanseItem)
        {
            expenseItemData.Add(new ExpenseItemModel()
            {
                Id = item.Id,
                Name = item.Name,
                Quantity = item.Quantity,
                Amount = item.Amount
            });
        }

        ExpenseItem = expenseItemData;

        var orgInfo = _organizationServices.GetOrganizations(expense.OrgId);
        OrgName = orgInfo.Name;
        OrgLogo = orgInfo.Logo;
        OrgAddress = orgInfo.Address;
        OrgEmail = orgInfo.Email;
        OrgPhone = orgInfo.Phone;


    }
    
}
