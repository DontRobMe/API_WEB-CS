using System.ComponentModel.DataAnnotations.Schema;

namespace TP_CS.Business.Models;

public class Team
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long? LeaderUserId { get; set; }
    
    public long? projectId { get; set; }
    
    public List<User> Users { get; set; } = new();
}