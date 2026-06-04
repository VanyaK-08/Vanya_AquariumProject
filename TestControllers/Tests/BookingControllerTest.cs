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
    }
}
