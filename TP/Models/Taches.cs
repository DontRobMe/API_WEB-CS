namespace TP.Models;

public class Taches 
{
    public long id { get; set; }
    public string Name { get; set; }
    public bool completed { get; set; }
    public long UtilisateurId { get; set; }


    public static long _nextTaskId = 1;
    public static readonly List<Taches> _tasks = new List<Taches>();
    
}