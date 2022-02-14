namespace EML.DataAccess;

public interface IUnitOfWork : IDisposable
{
    void Save();
}
