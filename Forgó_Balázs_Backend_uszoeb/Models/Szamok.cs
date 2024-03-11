using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Forgó_Balázs_Backend_uszoeb.Models;

public partial class Szamok
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public int VersenyzoId { get; set; }
    [JsonIgnore]
    public virtual Versenyzok Versenyzo { get; set; } = null!;
}
