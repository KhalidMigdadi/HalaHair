using System;
using System.Collections.Generic;

namespace HalaHair.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Gender { get; set; }

    public string? ProfileImagePath { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Appointment> AppointmentBarbers { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentUsers { get; set; } = new List<Appointment>();

    public virtual ICollection<BarberService> BarberServices { get; set; } = new List<BarberService>();

    public virtual ICollection<BarberUnavailableSlot> BarberUnavailableSlots { get; set; } = new List<BarberUnavailableSlot>();

    public virtual ICollection<BarberWorkingHour> BarberWorkingHours { get; set; } = new List<BarberWorkingHour>();

    public virtual ICollection<BookingsHistory> BookingsHistoryBarbers { get; set; } = new List<BookingsHistory>();

    public virtual ICollection<BookingsHistory> BookingsHistoryUsers { get; set; } = new List<BookingsHistory>();

    public virtual ICollection<CommissionPenalty> CommissionPenaltyBarbers { get; set; } = new List<CommissionPenalty>();

    public virtual ICollection<CommissionPenalty> CommissionPenaltyUsers { get; set; } = new List<CommissionPenalty>();

    public virtual ICollection<FavoriteBarber> FavoriteBarberBarbers { get; set; } = new List<FavoriteBarber>();

    public virtual ICollection<FavoriteBarber> FavoriteBarberUsers { get; set; } = new List<FavoriteBarber>();

    public virtual ICollection<FavoriteSalon> FavoriteSalons { get; set; } = new List<FavoriteSalon>();

    public virtual ICollection<FavoriteService> FavoriteServices { get; set; } = new List<FavoriteService>();

    public virtual LoyaltyPoint? LoyaltyPoint { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Review> ReviewBarbers { get; set; } = new List<Review>();

    public virtual ICollection<Review> ReviewUsers { get; set; } = new List<Review>();

    public virtual ICollection<Salon> Salons { get; set; } = new List<Salon>();
}
