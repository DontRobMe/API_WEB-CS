namespace TP_CS.DTOs
{
  

    public class TaskCreateDto
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
        public long UtilisateurId { get; set; }
    }
    
    public class TaskUpdateDto
    {
        public bool Completed { get; set; }
    }
    
    public class UserDto
    {
        public long Id { get; set; }
        public string Nom { get; set; }
    }

    public class UserCreateDto
    {
        public string Nom { get; set; }
    }
}