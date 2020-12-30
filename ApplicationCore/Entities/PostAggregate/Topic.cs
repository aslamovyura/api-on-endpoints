namespace ApplicationCore.Entities.PostAggregate
{
    public class Topic: BaseEntity
    {
        public string Name { get; private set; }

        private Topic() { }

        public Topic(string name)
        {
            Name = name;
        }
    }
}