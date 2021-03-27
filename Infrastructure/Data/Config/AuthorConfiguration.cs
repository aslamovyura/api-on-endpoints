using ApplicationCore.Entities.AuthorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Author.Address));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}