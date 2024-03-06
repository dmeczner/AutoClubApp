using System;
using System.Collections.Generic;

namespace AutoClubBlazorApp.AutoClubEntities;

public partial class Car
{
    public int Id { get; set; }

    public string? CarBrand { get; set; }

    public string? Type { get; set; }

    public string? LicensePlate { get; set; }

    public DateTime? TimeOfProduction { get; set; }

    public virtual ICollection<OwnersAndCarsConnection> OwnersAndCarsConnections { get; set; } = new List<OwnersAndCarsConnection>();
}
