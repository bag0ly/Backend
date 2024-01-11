namespace Books_n_Authors.Dtos
{
    public record AuthorDto(Guid Id, string Name, string Gender, DateOnly Birthdate, Guid Nationality);
    public record CreateAuthorDto(string Name, string Gender, DateOnly Birthdate, Guid Nationality);
    public record UpdateAuthorDto(string Name, string Gender, DateOnly Birthdate, Guid Nationality);
}
