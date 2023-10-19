namespace TP1_Gestion_d_une_Liste_de_Taches.Models;

public class Taches : Priorite
{
    public long id { get; set; }
    public string Name { get; set; }
    public bool Statut { get; set; }
    public priorite Priorite { get; set; }
    public long UtilisateurId { get; set; }


    public static long _nextTaskId = 1;
    public static readonly List<Taches> _tasks = new List<Taches>();
    public void CreateTask(string taskName, long userId, bool statut, priorite priorite)
    {
        var task = new Taches
        {
            id = _nextTaskId,
            Name = taskName,
            UtilisateurId = userId,
            Statut = statut,
            Priorite = priorite
        };
        _tasks.Add(task);
        _nextTaskId++;
    }
}