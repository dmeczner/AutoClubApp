using System;
using System.Collections.Generic;

namespace AutoClubBlazorApp.AutoClubEntities;

public partial class Owner
{
    public int Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public DateTime? Birthday { get; set; }

    public virtual ICollection<OwnersAndCarsConnection> OwnersAndCarsConnections { get; set; } = new List<OwnersAndCarsConnection>();
}
