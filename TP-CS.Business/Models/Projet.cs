namespace TP_CS.Business.Models;

public class Project
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public bool Status { get; set; }
    public long ResponsibleUserId { get; set; }
    public List<Task> Tasks { get; set; }
    public List<Tag> Tags { get; set; }
}