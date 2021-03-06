﻿using System.Data.Entity.ModelConfiguration;
using Domain.Programmers;

namespace DataAccess.Configurations
{
    public class ProgrammerConfiguration : EntityTypeConfiguration<Programmer>
    {
        public ProgrammerConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name).IsRequired().HasMaxLength(100);
            Property(p => p.Bio).HasMaxLength(255);
            Property(p => p.BlogUrl).HasMaxLength(100);

            HasMany(programmer => programmer.Languages)
                .WithOptional()
                .HasForeignKey(language => language.Id);
        }
    }
}