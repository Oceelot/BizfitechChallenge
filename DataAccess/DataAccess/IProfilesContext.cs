using System.Data;
using System.Linq;
using Domain;

namespace DataAccess
{
    public interface IProfilesContext
    {
        IDbConnection Connection { get; }
        IQueryable<T> GetEntities<T>() where T : Entity;
    }
}