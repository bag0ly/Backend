using System;
using System.Collections.Generic;

namespace Books_n_Authors.Models;

public partial class Nationality
{
    public Guid Id { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
