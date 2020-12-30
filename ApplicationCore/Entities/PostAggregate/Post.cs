using ApplicationCore.Entities.PostAggregate;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;

namespace ApplicationCore.Entities
{
    public class Post : BaseEntity, IAggregateRoot
    {
        public Topic Topic { get; private set; }
        public string Title { get; set; }
        public string Content { get; set; }

        private Post() { }

        public Post(Topic topic, string title, string content)
        {
            Guard.Against.Null(topic, nameof(topic));
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.NullOrEmpty(content, nameof(content));

            Topic = topic;
            Title = title;
            Content = content;
        }
    }
}