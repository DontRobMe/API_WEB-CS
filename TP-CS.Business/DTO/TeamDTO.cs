namespace TP_CS.Business.DTO;

public class TeamDto
{
    public class CreateTeamDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long LeaderUserId { get; set; }
        public long projectId { get; set; }
    }
    
    public class UpdateTeamDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}