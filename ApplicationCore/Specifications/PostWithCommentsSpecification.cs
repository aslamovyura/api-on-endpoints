using ApplicationCore.Entities.PostAggregate;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
    public class PostWithCommentsSpecification : Specification<Post>
    {
        public PostWithCommentsSpecification(int postId)
        {
            Query
                .Where(p => p.Id == postId)
                .Include(p => p.Comments);
        }
    }
}