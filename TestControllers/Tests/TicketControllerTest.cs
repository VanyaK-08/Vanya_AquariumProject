using AquariumController;
using AquariumData;
using AquariumData.Entities;
using AquariumData.Enums;
using TestControllers.Saving;

namespace TestControllers.Tests
{
    public class TicketControlTests
    {
        private TicketController controller;
        [SetUp]
        public void Setup()
        {
            AquariumContext context = TestDBStuff.CreateContext();
            context.Users.Add(new Userr
            {
                Id = 1,
                Username = "Petur08",
                Email = "petur.08@gmail.com",
                Password = "password123",
                Role = Role.Client
            });
            context.Exhibits.Add(new Exhibit
            {
                Id = 1,
                Title = "Exhibit1",
                Description = "Description1"
            });
            context.Users.Add(new Userr
            {
                Id = 2,
                Username = "Employee1",
                Email = "employee1@gmail.com",
                Password = "pass123",
                Role = Role.Employee
            });
            context.Bookings.Add(new Booking
            {
                Id = 1,
                BookingDate = DateTime.Parse("2026-07-07"),
                UserEmployeeId = 2
            });
            context.SaveChanges();
            controller = new TicketController(context);
        }
        [Test]
        public async Task AddTicket_SuccessfullyAddTicket()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 1
            };
            await controller.AddTicket(ticket);
            var tickets = await controller.GetAllTickets();
            var addedTicket = tickets.FirstOrDefault();
            Assert.IsNotNull(addedTicket);
            Assert.AreEqual(20, addedTicket.Price);
            Assert.AreEqual(DateTime.Parse("2026-08-08"), addedTicket.VisitDate);
            Assert.AreEqual(1, addedTicket.ExhibitId);
            Assert.AreEqual(1, addedTicket.BookingId);
        }
        [Test]
        public async Task AddTicket_PastVisitDate_ThrowsException()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2020-01-01"),
                ExhibitId = 1,
                BookingId = 1
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddTicket(ticket));
        }
        [Test]
        public async Task AddTicket_NegativePrice_ThrowsException()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = -10,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 1
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddTicket(ticket));
        }
        [Test]
        public async Task AddTicket_NonExistingBooking_ThrowsException()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 999
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddTicket(ticket));
        }
        [Test]
        public async Task UpdateTicket_SuccessfullyUpdateTicket()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 1
            };
            await controller.AddTicket(ticket);
            ticket.Price = 25;
            ticket.VisitDate = DateTime.Parse("2026-09-09");
            await controller.UpdateTicket(ticket);
            var tickets = await controller.GetAllTickets();
            var updatedTicket = tickets.FirstOrDefault();
            Assert.IsNotNull(updatedTicket);
            Assert.AreEqual(25, updatedTicket.Price);
            Assert.AreEqual(DateTime.Parse("2026-09-09"), updatedTicket.VisitDate);
        }
        [Test]
        public async Task UpdateTicket_NonExistingTicket_ThrowsException()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 1
            };
            await controller.AddTicket(ticket);
            ticket.Id = 999;
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateTicket(ticket));
        }
        [Test]
        public async Task UpdateTicket_PastVisitDate_ThrowsException()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 1
            };
            await controller.AddTicket(ticket);
            ticket.VisitDate = DateTime.Parse("2020-01-01");
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateTicket(ticket));
        }
        [Test]
        public async Task UpdateTicket_NegativePrice_ThrowsException()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 1
            };
            await controller.AddTicket(ticket);
            ticket.Price = -10;
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateTicket(ticket));
        }
        [Test]
        public async Task UpdateTicket_NonExistingBooking_ThrowsException()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 1
            };
            await controller.AddTicket(ticket);
            ticket.BookingId = 999;
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateTicket(ticket));
        }
        [Test]
        public async Task GetAllTickets_ReturnsAllTickets()
        {
            Ticket ticket1 = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 1
            };
            Ticket ticket2 = new Ticket
            {
                Id = 2,
                Price = 30,
                VisitDate = DateTime.Parse("2026-09-09"),
                ExhibitId = 1,
                BookingId = 1
            };
            await controller.AddTicket(ticket1);
            await controller.AddTicket(ticket2);
            var tickets = await controller.GetAllTickets();
            Assert.AreEqual(2, tickets.Count);
        }
        [Test]
        public async Task BookTicketClient_SuccessfullyBooksTicket()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 1
            };
            await controller.AddTicket(ticket);
            var client = new Userr
            {
                Id = 1,
                Username = "Petur08",
                Email = "petur.08@gmail.com",
                Password = "password123",
                Role = Role.Client
            };
            //await controller.BookTicketClient(ticket, client);
            var bookedTicket = (await controller.GetAllTickets()).First();
        }
        [Test]
        public void BookTicketClient_NonExistingTicket_ThrowsException()
        {
            Ticket ticket = new Ticket
            {
                Id = 999
            };
            Userr client = new Userr
            {
                Id = 1,
                Role = Role.Client
            };
            //Assert.ThrowsAsync<ArgumentException>(async () => await controller.BookTicketClient(ticket, client));
        }
        [Test]
        public async Task BookTicketClient_NonExistingClient_ThrowsException()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 1
            };
            await controller.AddTicket(ticket);
            Userr client = new Userr
            {
                Id = 999,
                Role = Role.Client
            };
            //Assert.ThrowsAsync<ArgumentException>(async () => await controller.BookTicketClient(ticket, client));
        }
        [Test]
        public async Task UnbookTicketClient_SuccessfullyUnbooksTicket()
        {
            Ticket ticket = new Ticket
            {
                Id = 1,
                Price = 20,
                VisitDate = DateTime.Parse("2026-08-08"),
                ExhibitId = 1,
                BookingId = 1
            };
            await controller.AddTicket(ticket);
            Userr client = new Userr
            {
                Id = 1,
                Role = Role.Client
            };
            //await controller.BookTicketClient(ticket, client);
            //await controller.UnbookTicketClient(ticket);
            var unbookedTicket = (await controller.GetAllTickets()).First();
        }
        [Test]
        public void UnbookTicketClient_NonExistingTicket_ThrowsException()
        {
            Ticket ticket = new Ticket
            {
                Id = 999
            };
            //Assert.ThrowsAsync<ArgumentException>(async () => await controller.UnbookTicketClient(ticket));
        }
        
    }
}
