using System.Collections.Generic;

namespace TP_CS.Business.Models;

public class User
{
    public long id { get; set; }
    public string Nom { get; set; }

    public static long _nextUserId = 1;
    public static readonly List<User> _users = new List<User>();
}