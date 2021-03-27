using ApplicationCore.Entities.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Post.Topic));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}