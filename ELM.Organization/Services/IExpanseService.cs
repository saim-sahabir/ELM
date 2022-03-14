using ELM.Organization.BusinessObjects;

namespace ELM.Organization.Services;

public interface IExpanseService
{
    int AddExpanseWithItem(Expanse expanse,  List<ExpanseItems> expanseItemsList);
    List<Expanse> GetAllExpense(int orgId);
    List<ExpanseItems> GetExpenseItem(int expenseId);
    Expanse GetExpanseById(int id);
}