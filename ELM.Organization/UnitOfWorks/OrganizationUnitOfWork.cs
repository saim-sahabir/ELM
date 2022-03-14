using ELM.Organization.DbContext;
using ELM.Organization.Repositories;
using EML.DataAccess;

namespace ELM.Organization.UnitOfWorks;

public class OrganizationUnitOfWork : UnitOfWork , IOrganizationUnitOfWork
{
    public IOrganizationRepository Organization { get; private set; }
    public IExpenseRepository Expense { get; private set; }
    
    public IExpenseItemRepository ExpenseItem { get; private set; }
    public OrganizationUnitOfWork(IOrganizationDbContext dbContext , 
        IOrganizationRepository organizationRepository,
        IExpenseRepository expenseRepository,
        IExpenseItemRepository expenseItemRepository
        ) : base((Microsoft.EntityFrameworkCore.DbContext)dbContext)
    {
        Organization = organizationRepository;
        Expense = expenseRepository;
        ExpenseItem = expenseItemRepository;

    }
}