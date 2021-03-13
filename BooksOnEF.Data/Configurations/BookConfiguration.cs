using BooksOnEF.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksOnEF.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.NbrInStock)
                .IsRequired();

            builder
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");

            builder
                .Property(m => m.Title)
                .IsRequired();

            builder
                .Property(m => m.Description);

            builder
                .Property(m => m.Edition)
                .IsRequired(false);

            builder
                .Property(m => m.ISBN);

            builder
                .Property(m => m.PublicationDate)
                .IsRequired(false);
             
            builder
                .Property(m => m.TotalPages)
                .IsRequired(false);
            

            builder
                .HasOne(m => m.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(m => m.AuthorId);


            builder.ToTable("Book");
        }
    }
}