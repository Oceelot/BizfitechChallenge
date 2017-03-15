using System.Data.Entity.ModelConfiguration;
using Domain.Programmers;

namespace DataAccess.Configurations
{
    public class ProgrammerConfiguration : EntityTypeConfiguration<Programmer>
    {
        public ProgrammerConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Bio).HasMaxLength(255);
            Property(p => p.BlogUrl).HasMaxLength(255);
        }
    }
}