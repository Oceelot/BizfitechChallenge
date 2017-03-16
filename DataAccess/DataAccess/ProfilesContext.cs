using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Domain;

namespace DataAccess
{
    public class ProfilesContext : DbContext, IProfilesContext
    {
        public ProfilesContext()
        {
            Database.SetInitializer<ProfilesContext>(null);
        }

        public IDbConnection Connection => Database.Connection;

        public IQueryable<T> GetEntities<T>() where T : Entity 
        {
            return Set<T>();
        }

        public T GetEntityById<T>(Guid id) where T : Entity
        {
            return Set<T>().SingleOrDefault(entity => entity.Id == id);
        }

        public void InsertEntity<T>(T entity) where T : Entity
        {
            Set<T>().Add(entity);
        }

        public void RemoveEntity<T>(T entity) where T : Entity
        {
            Set<T>().Remove(entity);
        }
    }
}