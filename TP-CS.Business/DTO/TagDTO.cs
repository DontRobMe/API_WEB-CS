namespace TP_CS.Business.DTO;

public class TagDto
{
    public class createTagDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public bool Iscomplete { get; set; }
    }
    
    public class updateTagDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        
        public bool IsComplete { get; set; }
    }
}