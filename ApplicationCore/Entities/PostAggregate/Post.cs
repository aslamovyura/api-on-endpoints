using System.Collections.Generic;
using ApplicationCore.Entities.AuthorAggregate;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;

namespace ApplicationCore.Entities.PostAggregate
{
    public class Post : BaseEntity, IAggregateRoot
    {
        public int TopicId { get; set; }
        public Topic Topic { get; private set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }

        private Post() { }

        public Post(int topicId, int authorId, string title, string content)
        {
            //Guard.Against.Null(topic, nameof(topic));
            //Guard.Against.Null(author, nameof(author));
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.NullOrEmpty(content, nameof(content));

            //TopicId = topic.Id;
            //Topic = topic;
            //AuthorId = author.Id;
            //Author = author;
            TopicId = topicId;
            AuthorId = authorId;
            Title = title;
            Content = content;
            Comments = new List<Comment>();
        }

        public Post(int topicId, int authorId, string title, string content, List<Comment> comments) : this(topicId, authorId, title, content)
        {
            Comments = comments;
        }
    }
}