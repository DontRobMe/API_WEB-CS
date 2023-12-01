namespace TP_CS.Business.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Nom { get; set; }
        
        public string role { get; set; }
        
        public List<Team> Teams { get; set; }
    }
}