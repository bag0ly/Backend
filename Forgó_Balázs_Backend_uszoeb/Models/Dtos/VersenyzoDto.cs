namespace Forgó_Balázs_Backend_uszoeb.Models.Dtos
{
    public record CreateVersenyzoDto(int Id,string Nev, int OrszagId, string Nem);

    public record UpdateVersenyzoDto(string Nev, int OrszagId, string Nem);
}

