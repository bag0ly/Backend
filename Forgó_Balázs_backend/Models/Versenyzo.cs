using System;
using System.Collections.Generic;

namespace Forgó_Balázs_backend.Models;

public partial class Versenyzo
{
    public int Id { get; set; }

    public string? Nev { get; set; }

    public string? SzakmaId { get; set; }

    public string? OrszagId { get; set; }

    public int? Pont { get; set; }

    public virtual Orszag? Orszag { get; set; }

    public virtual Szakma? Szakma { get; set; }
}
