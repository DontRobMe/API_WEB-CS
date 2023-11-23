using System.Collections.Generic;

namespace TP_CS.Business.Models;

public class Task 
{
    public long id { get; set; }
    public string Name { get; set; }
    public bool completed { get; set; }
    public long UtilisateurId { get; set; }


    public static long _nextTaskId = 1;
    
    public static readonly List<Task> _tasks = new List<Task>();
    
}