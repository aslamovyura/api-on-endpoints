using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities.PostAggregate;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;

namespace ApplicationCore.Entities.AuthorAggregate
{
    public class Author: BaseEntity, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        //public int AddressId { get; set; }

        public Address Address { get; set; }
        public List<Post> Posts { get; set; }

        private Author() { }

        public Author(string firstName, string lastName, DateTime birthDate)
        {
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Guard.Against.OutOfRange(birthDate, nameof(birthDate), DateTime.Parse("01-01-1900"), DateTime.Now);

            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public Author(string firstName, string lastName, DateTime birthDate, Address address)
            : this(firstName, lastName, birthDate)
        {
            Guard.Against.Null(address, nameof(address));
            //AddressId = address.Id;
            Address = address;
        }

        public Author(string firstName, string lastName, DateTime birthDate, Address address, List<Post> posts)
            : this(firstName, lastName, birthDate, address)
        {
            Guard.Against.Null(posts, nameof(posts));
            Posts = posts;
        }

        public int TotalPosts() => Posts.Count();
    }
}