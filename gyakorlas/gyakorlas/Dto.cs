namespace gyakorlas
{
    public class Dto
    {
        public record UserDto(Guid Id, string Name, int Age,
            string Email, DateTimeOffset Created);
        public record CreatedUserDto(string Name, int Age,
            string Email);
        public record UpdateUserDto(string Name, int Age,
            string Email);
        public record DeleteUserDto(Guid Id);
    }
}
