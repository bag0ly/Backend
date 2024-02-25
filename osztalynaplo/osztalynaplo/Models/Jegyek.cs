using System;
using System.Collections.Generic;

namespace Forgó_Balázs_Backend.Models;

public partial class Jegyek
{
    public int Id { get; set; }

    public int? JegySzammal { get; set; }

    public string? JegySzoveggel { get; set; }

    public DateTime? BeirasDatuma { get; set; }

    public DateTime? ModositasDatuma { get; set; }

    public int? IdTanarok { get; set; }

    public int? IdTantargyak { get; set; }

    public virtual Tanarok? IdTanarokNavigation { get; set; }

    public virtual Tantargyak? IdTantargyakNavigation { get; set; }
}
