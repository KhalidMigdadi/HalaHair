using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class Salon
{
    public int Id { get; set; }

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string AddressEn { get; set; } = null!;

    public string AddressAr { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public TimeOnly OpeningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }

    public bool IsClosed { get; set; }

    public string? ImageUrl { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string? AboutSalonEn { get; set; }

    public string? AboutSalonAr { get; set; }

    public bool IsVisible { get; set; }

    public bool IsPromoted { get; set; }

    public int BarberId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual User Barber { get; set; } = null!;

    public virtual ICollection<BookingsHistory> BookingsHistories { get; set; } = new List<BookingsHistory>();

    public virtual ICollection<FavoriteSalon> FavoriteSalons { get; set; } = new List<FavoriteSalon>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
