namespace API.PostEndpoints
{
    public class PostDto
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}