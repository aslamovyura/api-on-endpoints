using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Entities.PostAggregate;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.PostEndpoints
{
    public class GetById : BaseAsyncEndpoint<GetByIdPostRequest, GetByIdPostResponse>
    {
        private readonly IAsyncRepository<Post> _postRepository;

        public GetById(IAsyncRepository<Post> postRepository)
        {
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        }

        [HttpGet("api/posts/{PostId}")]
        [SwaggerOperation(
            Summary = "Get a Post by Id",
            Description = "Gets a Post by Id",
            OperationId = "posts.GetById",
            Tags = new[] { "PostEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdPostResponse>> HandleAsync([FromRoute] GetByIdPostRequest request, CancellationToken cancellationToken = default)
        {
            var response = new GetByIdPostResponse(request.CorrelationId());

            var post = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);
            if (post is null) return NotFound();

            response.Post = new PostDto
            {
                Id = post.Id,
                TopicId = post.TopicId,
                AuthorId = post.AuthorId,
                Title = post.Title,
                Content = post.Content
            };
            return Ok(response);
        }
    }
}