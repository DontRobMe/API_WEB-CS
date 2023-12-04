namespace TP_CS.Business.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        
        public string Role { get; set; }
        
        public long? TeamId { get; set; }
        public List<UserTask> UserTasks { get; set; } = new();
    }
}