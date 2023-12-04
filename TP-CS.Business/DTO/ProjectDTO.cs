namespace TP_CS.Business.DTO;

public class ProjectDTO
{
    public class CreateProjetDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
    
    public class UpdateProjetDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public long ResponsibleUserId { get; set; }

    }
}