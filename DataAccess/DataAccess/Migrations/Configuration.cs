using Domain.Languages;

namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.ProfilesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProfilesContext context)
        {
            context.InsertEntity(new Language { Id = Guid.NewGuid(), Description = "C#"});
            context.InsertEntity(new Language { Id = Guid.NewGuid(), Description = "C++"});
            context.InsertEntity(new Language { Id = Guid.NewGuid(), Description = "Java"});
            context.InsertEntity(new Language { Id = Guid.NewGuid(), Description = "SQL"});
            context.InsertEntity(new Language { Id = Guid.NewGuid(), Description = "Python"});
            context.InsertEntity(new Language { Id = Guid.NewGuid(), Description = "PHP"});
            context.SaveChanges();
        }
    }
}
