namespace TP_CS.Business.Models;

public class Project
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public bool Status { get; set; }
    public long ResponsibleUserId { get; set; }
    
    public List<Team> Teams { get; set; } = new();
    
    public List<UserTask> UserTasks { get; set; } = new();
}