using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HalaHair.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<BarberService> BarberServices { get; set; }

    public virtual DbSet<BarberUnavailableSlot> BarberUnavailableSlots { get; set; }

    public virtual DbSet<BarberWorkingHour> BarberWorkingHours { get; set; }

    public virtual DbSet<BookingsHistory> BookingsHistories { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CommissionPenalty> CommissionPenalties { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactReply> ContactReplies { get; set; }

    public virtual DbSet<FavoriteBarber> FavoriteBarbers { get; set; }

    public virtual DbSet<FavoriteSalon> FavoriteSalons { get; set; }

    public virtual DbSet<FavoriteService> FavoriteServices { get; set; }

    public virtual DbSet<JobApplication> JobApplications { get; set; }

    public virtual DbSet<JobOpportunity> JobOpportunities { get; set; }

    public virtual DbSet<LoyaltyPoint> LoyaltyPoints { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Salon> Salons { get; set; }

    public virtual DbSet<SalonImage> SalonImages { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<SubscriptionPackage> SubscriptionPackages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5U44ISQ;Database=HalaHair;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC07BAD41419");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Confirmed");
            entity.Property(e => e.TotalDuration).HasComputedColumnSql("(datediff(minute,[StartTime],[EndTime]))", true);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Barber).WithMany(p => p.AppointmentBarbers)
                .HasForeignKey(d => d.BarberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Barber");

            entity.HasOne(d => d.Salon).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.SalonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Salon");

            entity.HasOne(d => d.Service).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Service");

            entity.HasOne(d => d.User).WithMany(p => p.AppointmentUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_User");
        });

        modelBuilder.Entity<BarberService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BarberSe__3214EC071414791A");

            entity.HasIndex(e => new { e.BarberId, e.ServiceId }, "UQ_Barber_Service").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Barber).WithMany(p => p.BarberServices)
                .HasForeignKey(d => d.BarberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BarberServices_Barber");

            entity.HasOne(d => d.Service).WithMany(p => p.BarberServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BarberServices_Service");
        });

        modelBuilder.Entity<BarberUnavailableSlot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BarberUn__3214EC072E36EDD7");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Reason).HasMaxLength(255);

            entity.HasOne(d => d.Barber).WithMany(p => p.BarberUnavailableSlots)
                .HasForeignKey(d => d.BarberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Barber_Unavailable");
        });

        modelBuilder.Entity<BarberWorkingHour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BarberWo__3214EC0713DB7EB8");

            entity.HasOne(d => d.Barber).WithMany(p => p.BarberWorkingHours)
                .HasForeignKey(d => d.BarberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BarberWor__Barbe__42E1EEFE");
        });

        modelBuilder.Entity<BookingsHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookings__3214EC07C6FBE55F");

            entity.ToTable("BookingsHistory");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Confirmed");
            entity.Property(e => e.TotalDuration).HasComputedColumnSql("(datediff(minute,[StartTime],[EndTime]))", true);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Barber).WithMany(p => p.BookingsHistoryBarbers)
                .HasForeignKey(d => d.BarberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Barber");

            entity.HasOne(d => d.Salon).WithMany(p => p.BookingsHistories)
                .HasForeignKey(d => d.SalonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Salon");

            entity.HasOne(d => d.Service).WithMany(p => p.BookingsHistories)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Booking_Service");

            entity.HasOne(d => d.User).WithMany(p => p.BookingsHistoryUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_User");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC077E1B588E");

            entity.HasIndex(e => e.NameEn, "UQ__Categori__EE1C70AF08B6BBAB").IsUnique();

            entity.HasIndex(e => e.NameAr, "UQ__Categori__EE1CD26C886241C5").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.NameAr).HasMaxLength(100);
            entity.Property(e => e.NameEn).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<CommissionPenalty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Commissi__3214EC0712D041CF");

            entity.Property(e => e.Amount).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.PenalizedParty)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Percentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Reason).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Appointment).WithMany(p => p.CommissionPenalties)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Commission_Appointment");

            entity.HasOne(d => d.Barber).WithMany(p => p.CommissionPenaltyBarbers)
                .HasForeignKey(d => d.BarberId)
                .HasConstraintName("FK_Commission_Barber");

            entity.HasOne(d => d.User).WithMany(p => p.CommissionPenaltyUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Commission_User");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacts__3214EC0767370326");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.IsReplied).HasDefaultValue(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SubjectAr).HasMaxLength(200);
            entity.Property(e => e.SubjectEn).HasMaxLength(200);
        });

        modelBuilder.Entity<ContactReply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactR__3214EC075ADC9074");

            entity.Property(e => e.RepliedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.RepliedBy).HasMaxLength(100);

            entity.HasOne(d => d.Contact).WithMany(p => p.ContactReplies)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactReplies_Contacts");
        });

        modelBuilder.Entity<FavoriteBarber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3214EC073E94630E");

            entity.HasIndex(e => new { e.UserId, e.BarberId }, "UQ_User_Barber").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");

            entity.HasOne(d => d.Barber).WithMany(p => p.FavoriteBarberBarbers)
                .HasForeignKey(d => d.BarberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FavBarber_Barber");

            entity.HasOne(d => d.User).WithMany(p => p.FavoriteBarberUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FavBarber_User");
        });

        modelBuilder.Entity<FavoriteSalon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3214EC070172524E");

            entity.HasIndex(e => new { e.UserId, e.SalonId }, "UQ_User_Salon").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");

            entity.HasOne(d => d.Salon).WithMany(p => p.FavoriteSalons)
                .HasForeignKey(d => d.SalonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Salon");

            entity.HasOne(d => d.User).WithMany(p => p.FavoriteSalons)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_User");
        });

        modelBuilder.Entity<FavoriteService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3214EC07D0FA0D28");

            entity.HasIndex(e => new { e.UserId, e.ServiceId }, "UQ_User_Service").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");

            entity.HasOne(d => d.Service).WithMany(p => p.FavoriteServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FavService_Service");

            entity.HasOne(d => d.User).WithMany(p => p.FavoriteServices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FavService_User");
        });

        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobAppli__3214EC07DBEAC42D");

            entity.ToTable("JobApplication");

            entity.Property(e => e.AppliedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.ResumeFilePath).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
        });

        modelBuilder.Entity<JobOpportunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobOppor__3214EC07EF914B17");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LocationAr).HasMaxLength(200);
            entity.Property(e => e.LocationEn).HasMaxLength(200);
            entity.Property(e => e.PositionAr).HasMaxLength(100);
            entity.Property(e => e.PositionEn).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<LoyaltyPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LoyaltyP__3214EC0787041912");

            entity.HasIndex(e => e.UserId, "UQ_LoyaltyPoints_User").IsUnique();

            entity.Property(e => e.LastUpdated).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.User).WithOne(p => p.LoyaltyPoint)
                .HasForeignKey<LoyaltyPoint>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LoyaltyPoints_User");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3214EC075A42DE06");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.PaymentDate).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.SecurityCodeHash).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TransactionId).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Payments)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_Appointment");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_User");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reviews__3214EC07AC0134A1");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Barber).WithMany(p => p.ReviewBarbers)
                .HasForeignKey(d => d.BarberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Barber");

            entity.HasOne(d => d.Salon).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.SalonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Salon");

            entity.HasOne(d => d.User).WithMany(p => p.ReviewUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_User");
        });

        modelBuilder.Entity<Salon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Salons__3214EC073C4E1DBE");

            entity.Property(e => e.AboutSalonAr).HasMaxLength(1000);
            entity.Property(e => e.AboutSalonEn).HasMaxLength(1000);
            entity.Property(e => e.AddressAr).HasMaxLength(255);
            entity.Property(e => e.AddressEn).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("U")
                .IsFixedLength();
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.IsClosed).HasColumnName("isClosed");
            entity.Property(e => e.IsVisible).HasDefaultValue(true);
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.NameAr).HasMaxLength(100);
            entity.Property(e => e.NameEn).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Barber).WithMany(p => p.Salons)
                .HasForeignKey(d => d.BarberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Salons_Barber");
        });

        modelBuilder.Entity<SalonImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SalonIma__3214EC074ECA6A80");

            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Services__3214EC0792B11536");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NameAr).HasMaxLength(100);
            entity.Property(e => e.NameEn).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Category).WithMany(p => p.Services)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Services_Category");

            entity.HasOne(d => d.Salon).WithMany(p => p.Services)
                .HasForeignKey(d => d.SalonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Services_Salon");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrip__3214EC0722A89FE8");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Package).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subscriptions_Package");

            entity.HasOne(d => d.Salon).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.SalonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subscriptions_Salon");
        });

        modelBuilder.Entity<SubscriptionPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrip__3214EC07E06F0EFB");

            entity.HasIndex(e => e.NameEn, "UQ__Subscrip__EE1C70AFCC071E4E").IsUnique();

            entity.HasIndex(e => e.NameAr, "UQ__Subscrip__EE1CD26CBF1D9A40").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr).HasMaxLength(100);
            entity.Property(e => e.NameEn).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07DF5E7951");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.ProfileImagePath).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updatedAt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
