using System;
using System.Collections.Generic;

namespace AutoClubBlazorApp.AutoClubEntities;

public partial class OwnersAndCarsConnection
{
    public int Id { get; set; }

    public int? OwnerId { get; set; }

    public int? CarId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Owner? Owner { get; set; }
}
