using AquariumData.Entities;
using AquariumData.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AquariumData
{
    public class AquariumContext : DbContext
    {
        public AquariumContext()
        {

        }

        public AquariumContext(DbContextOptions<AquariumContext> options) : base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Userr> Users { get; set; }
        public DbSet<ClientTicket> ClientsTickets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();
                string connectionstring = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionstring);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user
            modelBuilder.Entity<Userr>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Userr>()
                .Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Userr>()
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Userr>()
                .Property(u => u.Password)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Userr>()
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
                .Property(e => e.ImageUrl)
                .IsRequired();

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

            // client ticket
            modelBuilder.Entity<ClientTicket>()
                .HasKey(ct => ct.Id);

            modelBuilder.Entity<ClientTicket>()
                .HasOne(ct => ct.Ticket)
                .WithMany(t => t.ClientTickets)
                .HasForeignKey(ct => ct.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClientTicket>()
                .HasOne(ct => ct.Client)
                .WithMany(u => u.ClientTickets)
                .HasForeignKey(ct => ct.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Userr>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Userr>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Tank>()
                .ToTable(t => t.HasCheckConstraint("CK_Tank_CapacityLiters", "[CapacityLiters] > 0"));

            modelBuilder.Entity<Ticket>()
                .ToTable(t => t.HasCheckConstraint("CK_Ticket_Price", "[Price] >= 0"));

            modelBuilder.Entity<Userr>().HasData(
    new Userr
    {
        Id = 1,
        Username = "IvanIvanov06",
        Email = "ivan.ivanov.06@gmail.com",
        Password = "admin123",
        Role = Role.Employee
    },
    new Userr
    {
        Id = 2,
        Username = "MariaDimitrova03",
        Email = "mari.dimi.03@gmail.com",
        Password = "password123",
        Role = Role.Employee
    }
);
        }
    }
}
