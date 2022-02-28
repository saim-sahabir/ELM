using ELM.Organization.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELM.Organization.DbContext;

public interface IOrganizationDbContext
{
    DbSet<Organizations> Organizations { get; set; }
    DbSet<OrgMembers> OrgMembers { get; set; }
    DbSet<Expenses> Expenses { get; set; }
    DbSet<ExpenseItems> ExpenseItems { get; set; }
    DbSet<Deposit> Deposits { get; set; }
    DbSet<Notification> Notifications { get; set; }
}