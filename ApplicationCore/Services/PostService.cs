using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities.AuthorAggregate;
using ApplicationCore.Entities.PostAggregate;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;

namespace ApplicationCore.Services
{
    public class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IAsyncRepository<Comment> _commentRepository;


        public PostService(ILogger<PostService> logger, IAsyncRepository<Post> postRepository, IAsyncRepository<Comment> commentRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        }

        public async Task AddComment(int postId, Author author, string content)
        {
            var postSpec = new PostWithCommentsSpecification(postId);
            var post = await _postRepository.FirstOrDefaultAsync(postSpec);

            Guard.Against.NullPost(postId, post);

            var comment = new Comment(author.Id, postId, DateTime.Now, content);

            await _commentRepository.AddAsync(comment);
            post.Comments.Add(comment);
        }

        public async Task CreateNewPost(Author author, Topic topic, string tille, string content)
        {
            Guard.Against.Null(author, nameof(author));
            Guard.Against.Null(topic, nameof(topic));

            var post = new Post(topic.Id, author.Id, tille, content);
            await _postRepository.AddAsync(post);
        }

        public async Task<List<Comment>> GetComments(int postId)
        {
            var postSpec = new PostWithCommentsSpecification(postId);
            var post = await _postRepository.FirstOrDefaultAsync(postSpec);

            Guard.Against.NullPost(postId, post);

            return post.Comments;
        }
    }
}