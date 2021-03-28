using ApplicationCore.Entities.AuthorAggregate;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
    public sealed class AuthorWithAddressSpecification : Specification<Author>
    {
        public AuthorWithAddressSpecification(int authorId)
        {
            Query
                .Where(a => a.Id == authorId)
                .Include(a => a.Address);
        }
    }
}