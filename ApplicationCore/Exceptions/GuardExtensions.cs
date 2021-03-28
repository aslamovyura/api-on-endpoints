using ApplicationCore.Entities.AuthorAggregate;
using ApplicationCore.Entities.PostAggregate;
using Ardalis.GuardClauses;

namespace ApplicationCore.Exceptions
{
    public static class GuardExtensions
    {
        public static void NullAuthor(this IGuardClause guardClause, int authorId, Author author)
        {
            if (author == null)
                throw new AuthorNotFoundException(authorId);
        }

        public static void NullPost(this IGuardClause guardClause, int postId, Post post)
        {
            if (post == null)
                throw new PostNotFoundException(postId);
        }
    }
}