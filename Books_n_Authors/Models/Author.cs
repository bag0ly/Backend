using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Books_n_Authors.Models;

public partial class Author
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Birthdate { get; set; }

    public Guid? Nationality { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [JsonIgnore]
    public virtual Nationality? NationalityNavigation { get; set; }
}
