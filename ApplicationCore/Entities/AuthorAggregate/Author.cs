using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities.AuthorAggregate;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;

namespace ApplicationCore.Entities
{
    public class Author: BaseEntity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        private Author() { }

        public Author(string identity, string firstName, string lastName, DateTime birthDate)
        {
            Guard.Against.NullOrEmpty(identity, nameof(identity));
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Guard.Against.OutOfRange(birthDate, nameof(birthDate), DateTime.Parse("01-01-1900"), DateTime.Now);

            IdentityGuid = identity;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }


        public Author(string identity, string firstName, string lastName, DateTime birthDate, Address address)
            : this(identity, firstName, lastName, birthDate)
        {
            Guard.Against.Null(address, nameof(address));
            Address = address;
        }

        public Author(string identity, string firstName, string lastName, DateTime birthDate, Address address, IEnumerable<Post> posts)
            : this(identity, firstName, lastName, birthDate, address)
        {
            Guard.Against.Null(posts, nameof(posts));
            Posts = posts;
        }

        public int TotalPosts() => Posts.Count();
    }
}