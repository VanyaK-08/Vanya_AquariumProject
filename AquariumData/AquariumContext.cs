using AquariumData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AquariumData
{
    public class AquariumContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionstring = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionstring);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            //tank
            modelBuilder.Entity<Tank>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Tank>()
                .Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Tank>()
                .Property(t => t.WaterTemperature)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Tank>()
                .HasOne(t => t.Exhibit)
                .WithMany(e => e.Tanks)
                .HasForeignKey(t => t.ExhibitId)
                .OnDelete(DeleteBehavior.Cascade);

            //animal
            modelBuilder.Entity<Animal>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Animal>()
                .Property(a => a.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Animal>()
                .Property(a => a.Species)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Tank)
                .WithMany(t => t.Animals)
                .HasForeignKey(a => a.TankId)
                .OnDelete(DeleteBehavior.Cascade);

            //exhibit
            modelBuilder.Entity<Exhibit>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Exhibit>()
                .Property(e => e.Title)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Exhibit>()
                .Property(e => e.Theme)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Exhibit>()
                .Property(e => e.Description)
                .HasMaxLength(1000);

            modelBuilder.Entity<Exhibit>()
                .Property(e => e.EntryPrice)
                .HasColumnType("decimal(10,2)");

            //booking
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingDate)
                .IsRequired();

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Employee)
                .WithMany(u => u.EmployeeBookings)
                .HasForeignKey(b => b.UserEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            //bookingclient
            modelBuilder.Entity<BookingClient>()
                .HasKey(bc => new { bc.BookingId, bc.ClientId });

            modelBuilder.Entity<BookingClient>()
                .HasOne(bc => bc.Booking)
                .WithMany(b => b.BookingClients)
                .HasForeignKey(bc => bc.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookingClient>()
                .HasOne(bc => bc.Client)
                .WithMany(u => u.BookingClients)
                .HasForeignKey(bc => bc.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            //ticket
            modelBuilder.Entity<Ticket>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Price)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Ticket>()
                .Property(t => t.VisitDate)
                .IsRequired();

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Booking)
                .WithMany(b => b.Tickets)
                .HasForeignKey(t => t.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Exhibit)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.ExhibitId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Client)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
