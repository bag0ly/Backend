namespace Projects_dolgozat.Dtos
{
    public record UserDto(Guid UserID,string UserName,string Email);
    public record CreateUserDto(string UserName, string Email);
    public record UpdateUserDto(string UserName, string Email);
    public record UserTaskDto(Guid UserID,string UserName);
}
