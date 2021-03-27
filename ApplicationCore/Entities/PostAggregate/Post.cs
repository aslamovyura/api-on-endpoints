using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;

namespace ApplicationCore.Entities.PostAggregate
{
    public class Post : BaseEntity, IAggregateRoot
    {
        public int TopicId { get; set; }
        public Topic Topic { get; private set; }
        public string Title { get; set; }
        public string Content { get; set; }

        private Post() { }

        public Post(Topic topic, string title, string content)
        {
            Guard.Against.Null(topic, nameof(topic));
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.NullOrEmpty(content, nameof(content));

            TopicId = topic.Id;
            Topic = topic;
            Title = title;
            Content = content;
        }
    }
}