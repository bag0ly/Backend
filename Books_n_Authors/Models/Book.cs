using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Books_n_Authors.Models;

public partial class Book
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Genre { get; set; }

    public DateOnly? Published { get; set; }

    public Guid? Author { get; set; }
    [JsonIgnore]
    public virtual Author? AuthorNavigation { get; set; }
}
