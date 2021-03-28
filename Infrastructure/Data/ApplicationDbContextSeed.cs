using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities.AuthorAggregate;
using ApplicationCore.Entities.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                

                if (!await dbContext.Topics.AnyAsync())
                {
                    await dbContext.Topics.AddRangeAsync(
                        GetPreconfiguredTopics());

                    await dbContext.SaveChangesAsync();
                }

                if (!await dbContext.Authors.AnyAsync())
                {
                    await dbContext.Authors.AddRangeAsync(
                        GetPreconfiguredAuthors());

                    await dbContext.SaveChangesAsync();
                }

                if (!await dbContext.Posts.AnyAsync())
                {
                    await dbContext.Posts.AddRangeAsync(
                        GetPreconfiguredPosts());

                    await dbContext.SaveChangesAsync();
                }

                if (!await dbContext.Comments.AnyAsync())
                {
                    await dbContext.Comments.AddRangeAsync(
                        GetPreconfiguredComments());

                    await dbContext.SaveChangesAsync();
                }

                

                if (!await dbContext.Addresses.AnyAsync())
                {
                    await dbContext.Addresses.AddRangeAsync(
                        GetPreconfiguredAddresses());

                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<ApplicationDbContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(dbContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static List<Address> GetPreconfiguredAddresses()
        {
            return new List<Address>()
            {
                new Address(1, "Lenina", "Minsk", "", "Belarus", "220045"),
                new Address(2, "Sovetskaya", "Gomel", "Gomelskaya obl.", "Belarus", "220000"),
                new Address(2, "Sovetskaya1", "Mogilev", "Mogilevskaya obl.", "Belarus", "220010"),
            };
        }

        static List<Topic> GetPreconfiguredTopics()
        {
            return new List<Topic>()
            {
                new Topic("Nature"),
                new Topic("War"),
                new Topic("Economy"),
            };
        }

        static List<Post> GetPreconfiguredPosts()
        {
            //var topics = GetPreconfiguredTopics();
            //var authors = GetPreconfiguredAuthors();
            //var comments = GetPreconfiguredComments();

            return new List<Post>()
            {
                new Post(1, 2, "Birds", "Some sample content of the article."),
                new Post(2, 1, "WW2", "Some another sample contect of the article."),
            };
        }

        static List<Author> GetPreconfiguredAuthors()
        {
            //var addresses = GetPreconfiguredAddresses();
            //var posts = GetPreconfiguredPosts();

            return new List<Author>()
            {
                //new Author("Mike","Pirce",DateTime.Parse("10-02-1984"),addresses[0], posts.GetRange(0,1)),
                //new Author("Andy","Anderson",DateTime.Parse("04-07-1957"),addresses[1], posts.GetRange(1,1)),
                new Author("Mike","Pirce",DateTime.Parse("10-02-1984")),
                new Author("Andy","Anderson",DateTime.Parse("04-07-1957")),
                new Author("Sam","Smith",DateTime.Parse("01-15-1955")),
            };
        }

        static List<Comment> GetPreconfiguredComments()
        {
            //var authors = GetPreconfiguredAuthors();
            //var posts = GetPreconfiguredPosts();

            return new List<Comment>()
            {
                new Comment(1, 2, DateTime.Parse("10-01-2020"),"Foo"),
                new Comment(2, 1, DateTime.Parse("10-02-2020"),"Foo-2"),
            };
        }
    }
}