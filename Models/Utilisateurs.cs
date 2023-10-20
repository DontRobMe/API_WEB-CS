namespace TP.Models;

public class Utilisateurs
{
    public long id { get; set; }
    public string Nom { get; set; }

    public static long _nextUserId = 1;
    public static readonly List<Utilisateurs> _users = new List<Utilisateurs>();
}