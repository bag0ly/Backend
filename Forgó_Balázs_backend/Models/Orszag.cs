using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Forgó_Balázs_backend.Models;

public partial class Orszag
{
    public string Id { get; set; } = null!;

    public string? OrszagNev { get; set; }
    [JsonIgnore]
    public virtual ICollection<Versenyzo> Versenyzos { get; set; } = new List<Versenyzo>();
}
