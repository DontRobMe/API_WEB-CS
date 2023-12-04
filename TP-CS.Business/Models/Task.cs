namespace TP_CS.Business.Models
{
    public class UserTask
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }

        public long? UserId { get; set; }
        
        public long? ProjectId { get; set; }
        
        public List<Tag> Tags { get; set; } = new();
    }
}