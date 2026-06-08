using AquariumController;
using AquariumData;
using AquariumData.Entities;
using TestControllers.Saving;

namespace TestControllers.Tests
{
    public class BookingControlTests
    {
        private BookingController controller;
        [SetUp]
        public void Setup()
        {
            AquariumContext context = TestDBStuff.CreateContext();
            context.Users.Add(new Userr
            {
                Id = 1,
                Username = "Petur08",
                Email = "petur.08@gmail.com"
            });
            context.SaveChanges();
            controller = new BookingController(context);
        }

        [Test]
        public async Task AddBooking_SuccessfullyAddBooking()
        {
            Booking booking = new Booking
            {
                BookingDate = DateTime.Parse("2026-07-07"),
                UserEmployeeId = 1,
                Tickets = null
            };
            await controller.AddBooking(booking);
            var bookings = await controller.GetAllBookings();
            var addedBooking = bookings.FirstOrDefault();
            Assert.IsNotNull(addedBooking);
            Assert.AreEqual(DateTime.Parse("2026-07-07"), addedBooking.BookingDate);
            Assert.AreEqual(1, addedBooking.UserEmployeeId);
            Assert.AreEqual(null, addedBooking.Tickets);
        }
        [Test]
        public void AddBooking_PastDate_ThrowsException()
        {
            Booking booking = new Booking
            {
                BookingDate = DateTime.Parse("2020-01-01"),
                UserEmployeeId = 1,
                Tickets = null
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddBooking(booking));
        }
        [Test]
        public async Task UpdateBooking_SuccessfullyUpdateBooking()
        {
            Booking booking = new Booking
            {
                BookingDate = DateTime.Parse("2026-07-07"),
                UserEmployeeId = 1,
                Tickets = null
            };
            await controller.AddBooking(booking);
            var bookings = await controller.GetAllBookings();
            var addedBooking = bookings.FirstOrDefault();
            addedBooking.BookingDate = DateTime.Parse("2026-08-08");
            await controller.UpdateBooking(addedBooking);
            var updatedBookings = await controller.GetAllBookings();
            var updatedBooking = updatedBookings.FirstOrDefault();
            Assert.IsNotNull(updatedBooking);
            Assert.AreEqual(DateTime.Parse("2026-08-08"), updatedBooking.BookingDate);
        }
        [Test]
        public void UpdateBooking_PastDate_ThrowsException()
        {
            Booking booking = new Booking
            {
                BookingDate = DateTime.Parse("2026-07-07"),
                UserEmployeeId = 1,
                Tickets = null
            };
            controller.AddBooking(booking).Wait();
            var bookings = controller.GetAllBookings().Result;
            var addedBooking = bookings.FirstOrDefault();
            addedBooking.BookingDate = DateTime.Parse("2020-01-01");
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateBooking(addedBooking));
        }
        [Test]
        public void UpdateBooking_NonExistentBooking_ThrowsException()
        {
            Booking booking = new Booking
            {
                Id = 999,
                BookingDate = DateTime.Parse("2026-07-07"),
                UserEmployeeId = 1,
                Tickets = null
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateBooking(booking));
        }
        [Test]
        public async Task GetBookingForEmployee_ReturnsCorrectBookings()
        {
            Booking booking1 = new Booking
            {
                BookingDate = DateTime.Parse("2026-07-07"),
                UserEmployeeId = 1,
                Tickets = null
            };
            Booking booking2 = new Booking
            {
                BookingDate = DateTime.Parse("2026-08-08"),
                UserEmployeeId = 1,
                Tickets = null
            };
            await controller.AddBooking(booking1);
            await controller.AddBooking(booking2);
            var employee = new Userr { Id = 1 };
            var bookingsForEmployee = await controller.GetBookingForEmployee(employee);
            Assert.AreEqual(2, bookingsForEmployee.Count);
            Assert.IsTrue(bookingsForEmployee.Any(b => b.BookingDate == DateTime.Parse("2026-07-07")));
            Assert.IsTrue(bookingsForEmployee.Any(b => b.BookingDate == DateTime.Parse("2026-08-08")));
        }
        [Test]
        public async Task GetAllBookings_ReturnsAllBookings()
        {
            Booking booking1 = new Booking
            {
                BookingDate = DateTime.Parse("2026-07-07"),
                UserEmployeeId = 1,
                Tickets = null
            };
            Booking booking2 = new Booking
            {
                BookingDate = DateTime.Parse("2026-08-08"),
                UserEmployeeId = 1,
                Tickets = null
            };
            await controller.AddBooking(booking1);
            await controller.AddBooking(booking2);
            var allBookings = await controller.GetAllBookings();
            Assert.AreEqual(2, allBookings.Count);
            Assert.IsTrue(allBookings.Any(b => b.BookingDate == DateTime.Parse("2026-07-07")));
            Assert.IsTrue(allBookings.Any(b => b.BookingDate == DateTime.Parse("2026-08-08")));
        }
    }
}
