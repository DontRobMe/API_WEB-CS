namespace TP_CS.Business.Models;

public class User
{
    public long Id { get; set; }
    public required string Nom { get; set; }

    public static long _nextUserId = 1;
    
    public static readonly List<User> _users = new List<User>();
}