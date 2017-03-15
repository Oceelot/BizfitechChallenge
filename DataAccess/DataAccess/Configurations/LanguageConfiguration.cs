using System.Data.Entity.ModelConfiguration;
using Domain.Languages;

namespace DataAccess.Configurations
{
    public class LanguageConfiguration : EntityTypeConfiguration<Language>
    {
        public LanguageConfiguration()
        {
            HasKey(l => l.Id);

            Property(l => l.Description).IsRequired().HasMaxLength(255);
        }
    }
}