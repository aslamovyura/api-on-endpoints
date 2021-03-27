using ApplicationCore.Entities.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired();

            var authorNavigation = builder.Metadata.FindNavigation(nameof(Comment.Author));
            authorNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var postNavigation = builder.Metadata.FindNavigation(nameof(Comment.Post));
            postNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}