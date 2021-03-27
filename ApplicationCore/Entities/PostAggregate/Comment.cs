using System;
using ApplicationCore.Entities.AuthorAggregate;
using Ardalis.GuardClauses;

namespace ApplicationCore.Entities.PostAggregate
{
    public class Comment: BaseEntity
    {
        public int AuthorId { get; set; }
        public Author Author { get; private set; }
        public int PostId { get; set; }
        public Post Post { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Content { get; set; }

        private Comment() { }

        public Comment(Author author, Post post, DateTime createdAt, string content)
        {
            Guard.Against.Null(author, nameof(author));
            Guard.Against.Null(post, nameof(post));
            Guard.Against.OutOfRange(createdAt, nameof(createdAt), DateTime.Parse("01-01-1900"), DateTime.Now);
            Guard.Against.NullOrEmpty(content, nameof(content));

            AuthorId = author.Id;
            Author = author;
            PostId = post.Id;
            Post = post;
            CreatedAt = createdAt;
            Content = content;
        }
    }
}