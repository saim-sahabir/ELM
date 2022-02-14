using Microsoft.EntityFrameworkCore;

namespace EML.DataAccess;

public abstract class UnitOfWork : IUnitOfWork
{
    protected readonly DbContext _dbContext;
    
    public UnitOfWork(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public virtual void Dispose() => _dbContext?.Dispose();
    public virtual void Save() => _dbContext?.SaveChanges();

}