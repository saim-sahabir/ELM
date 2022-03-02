using ELM.Organization.BusinessObjects;
using ELM.Organization.DbContext;
using ELM.Organization.Entities;
using EML.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ELM.Organization.Repositories;

public class OrganizationRepository : Repository<Organizations, int> ,  IOrganizationRepository
{
    private readonly IOrganizationDbContext _context;
    
    public OrganizationRepository(IOrganizationDbContext context) : base((Microsoft.EntityFrameworkCore.DbContext)context)
    {
        _context = context;
    }
    
    public Organizations GetOrganizationsBySetup(int id, string userId)
    {
        return _context.Organizations.Where(x => x.Id == id && x.OwnerId == userId).AsNoTracking().First();
    }
    
}