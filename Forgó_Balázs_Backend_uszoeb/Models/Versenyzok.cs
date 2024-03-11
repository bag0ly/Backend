using System;
using System.Collections.Generic;

namespace Forgó_Balázs_Backend_uszoeb.Models;

public partial class Versenyzok
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public int OrszagId { get; set; }

    public string Nem { get; set; } = null!;

    public virtual Orszagok Orszag { get; set; } = null!;

    public virtual ICollection<Szamok> Szamoks { get; set; } = new List<Szamok>();
}
