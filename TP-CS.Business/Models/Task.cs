namespace TP_CS.Business.Models;

public abstract class Task 
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public bool Completed { get; set; }
    public long UtilisateurId { get; set; }


    public static long _nextTaskId = 1;
    
    public static readonly List<Task> _tasks = new List<Task>();
}