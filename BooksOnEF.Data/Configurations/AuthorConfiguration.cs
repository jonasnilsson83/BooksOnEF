using BooksOnEF.Core.Models;
using BooksOnEF.Core.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksOnEF.Data.Configurations
{
    //Hmm ska vi kanske ha egna config entities och sedan projiceras till Core.Models?
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(k => k.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(m => m.LastName)
                .IsRequired()
                .HasMaxLength(250);

            builder.ToTable("Author");
        }
    }
}
