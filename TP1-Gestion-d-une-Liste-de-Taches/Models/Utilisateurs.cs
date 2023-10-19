namespace TP1_Gestion_d_une_Liste_de_Taches.Models;

public class Utilisateurs
{
    public long id { get; set; }
    public string Nom { get; set; }

    public static long _nextUserId = 1;
    public static readonly List<Utilisateurs> _users = new List<Utilisateurs>();
    
    public void CreateUser(string userName)
    {
        var user = new Utilisateurs
        {
            id = _nextUserId,
            Nom = userName
        };
        _users.Add(user);
        _nextUserId++;
    }
}