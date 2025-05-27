using Microsoft.EntityFrameworkCore;

public class HotelManagementContext : DbContext
{
    public HotelManagementContext(DbContextOptions<HotelManagementContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<InventoryEntity> Inventories { get; set; }
    public DbSet<ReservationRooms> ReservationRooms { get; set; }
    public DbSet<ReservationGuests> ReservationGuests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Reservation-ReservationRooms relationship
        modelBuilder.Entity<ReservationRooms>()
            .HasOne(rr => rr.Reservation)
            .WithMany()
            .HasForeignKey(rr => rr.ReservationId)
            .OnDelete(DeleteBehavior.Restrict); 

         // Configure composite primary key for ReservationGuests
    modelBuilder.Entity<ReservationRooms>()
        .HasKey(rg => new { rg.ReservationId, rg.RoomId });

        // Room-ReservationRooms relationship
        modelBuilder.Entity<ReservationRooms>()
            .HasOne(rr => rr.Room)
            .WithMany()
            .HasForeignKey(rr => rr.RoomId)
            .OnDelete(DeleteBehavior.Restrict); 

         // Configure composite primary key for ReservationGuests
    modelBuilder.Entity<ReservationGuests>()
        .HasKey(rg => new { rg.ReservationId, rg.GuestId });

    // Configure ReservationGuests - Reservation relationship
    modelBuilder.Entity<ReservationGuests>()
        .HasOne(rg => rg.Reservation)
        .WithMany(r => r.ReservationGuests)
        .HasForeignKey(rg => rg.ReservationId)
        .OnDelete(DeleteBehavior.Restrict);

    // Configure ReservationGuests - Guest relationship
    modelBuilder.Entity<ReservationGuests>()
        .HasOne(rg => rg.Guest)
        .WithMany() // A Guest can have multiple ReservationGuests
        .HasForeignKey(rg => rg.GuestId)
        .OnDelete(DeleteBehavior.Restrict);

        // Reservation-Payment relationship
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Reservation)
            .WithMany()
            .HasForeignKey(p => p.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);

        // Staff-Department relationship
        modelBuilder.Entity<Staff>()
            .HasOne(s => s.Department)
            .WithMany()
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Inventory-Room relationship
        modelBuilder.Entity<InventoryEntity>()
            .HasOne(i => i.Room)
            .WithMany()
            .HasForeignKey(i => i.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure UserRole to be stored as a string
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();
    }
}