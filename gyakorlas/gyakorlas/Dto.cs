namespace gyakorlas
{
    public class Dto
    {
        public record UserDto(Guid Id, string Name, string Email,
            int Age, string Created);
        public record CreatedUserDto(string Name, string Email, int Age);
        public record UpdateUserDto(string Name, string Email, int Age);
        public record DeleteUserDto(Guid Id);
    }
}
