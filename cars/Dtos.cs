namespace cars
{
    public record CarDto(Guid Id,string Modelname,string Description,DateTime Created);
    public record CreatedCarDto(string Modelname, string Description);
    public record UpdatedCarDto(string Modelname, string Description);
}
