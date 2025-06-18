using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class BarberWorkingHour
{
    public int Id { get; set; }

    public int BarberId { get; set; }

    public byte DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual User Barber { get; set; } = null!;
}
