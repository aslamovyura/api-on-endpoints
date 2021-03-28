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

            builder.HasOne(p => p.Author);
            builder.Property(p => p.AuthorId).IsRequired();

            builder.HasOne(p => p.Topic);
            builder.Property(p => p.TopicId ).IsRequired();

            //var topicNavigation = builder.Metadata.FindNavigation(nameof(Post.Topic));
            //topicNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            //var authorNavigation = builder.Metadata.FindNavigation(nameof(Post.Author));
            //authorNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            //var commentsNavigation = builder.Metadata.FindNavigation(nameof(Post.Comments));
            //commentsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}