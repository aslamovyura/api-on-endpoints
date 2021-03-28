namespace ApplicationCore.Entities.AuthorAggregate
{
    public class Address: BaseEntity
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        private Address() { }

        public Address(int authorId, string street, string city, string state, string country, string zipcode)
        {
            AuthorId = authorId;
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }
    }
}