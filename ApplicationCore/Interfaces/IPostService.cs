using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities.AuthorAggregate;
using ApplicationCore.Entities.PostAggregate;

namespace ApplicationCore.Interfaces
{
    public interface IPostService
    {
        Task CreateNewPost(Author author, Topic topic, string tille, string content);
        Task AddComment(int postId, Author author, string content);
        Task<List<Comment>> GetComments(int postId);
    }
}