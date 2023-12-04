namespace TP_CS.Business.DTO;

public record UserDto
{
    public class UserCreateDto
    {
        public string Nom { get; set; }
        
        public string Role { get; set; }
        
        public long TeamId { get; set; }

    }
    
    public class UpdateUserDto
    {
        public string Nom { get; set; }
        
    }
}