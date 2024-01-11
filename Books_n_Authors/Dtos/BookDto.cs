namespace Books_n_Authors.Dtos
{
    public record BookDto(Guid Id, string Name, string Genre, DateOnly Published, Guid Author);
    public record CreateBookDto(string Name, string Genre, DateOnly Published, Guid Author);
    public record UpdateBookDto(string Name, string Genre, DateOnly Published, Guid Author);
}
