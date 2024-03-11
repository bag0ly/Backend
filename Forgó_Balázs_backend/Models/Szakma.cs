using System;
using System.Collections.Generic;

namespace Forgó_Balázs_backend.Models;

public partial class Szakma
{
    public string Id { get; set; } = null!;

    public string? SzakmaNev { get; set; }

    public virtual ICollection<Versenyzo> Versenyzos { get; set; } = new List<Versenyzo>();
}
