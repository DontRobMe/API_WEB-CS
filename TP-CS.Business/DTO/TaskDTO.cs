namespace TP_CS.Business.DTO;

public record TaskDto
{
    public class CreateTaskDto
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
        public long UserId { get; set; }
        public long ProjectId { get; set; }
    }
}