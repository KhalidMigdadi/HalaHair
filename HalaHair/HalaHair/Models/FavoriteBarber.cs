using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class FavoriteBarber
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BarberId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Barber { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
