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
    }
}