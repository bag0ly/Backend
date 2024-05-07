using System;
using System.Collections.Generic;

namespace fb_backend_gyakorlas_01.Models;

public partial class Tantargyak
{
    public int Id { get; set; }

    public string? TantargyNev { get; set; }

    public string? TantargyLeiras { get; set; }

    public virtual ICollection<Jegyek> Jegyeks { get; set; } = new List<Jegyek>();
}
