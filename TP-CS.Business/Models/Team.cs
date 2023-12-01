namespace TP_CS.Business.Models;

public class Team
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<long> MemberUserIds { get; set; }
    public long LeaderUserId { get; set; }
    public List<Project> Projects { get; set; }
}