using System;
using System.Data;
using System.Linq;
using Domain;

namespace DataAccess
{
    public interface IProfilesContext
    {
        IDbConnection Connection { get; }
        IQueryable<T> GetEntities<T>() where T : Entity;
        T GetEntityById<T>(Guid id) where T : Entity;
        void InsertEntity<T>(T entity) where T : Entity;
        void RemoveEntity<T>(T entity) where T : Entity;
    }
}