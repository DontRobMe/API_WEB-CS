namespace TP1_Gestion_d_une_Liste_de_Taches.Models;

public class Taches 
{
    public long id { get; set; }
    public string Name { get; set; }
    public bool Statut { get; set; }
    public long UtilisateurId { get; set; }


    public static long _nextTaskId = 1;
    public static readonly List<Taches> _tasks = new List<Taches>();
    
}