using AquariumData;
using AquariumData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumController
{
    public class BookingController
    {
        private AquariumContext context;
        public BookingController()
        {
            context = new AquariumContext();
        }
        public BookingController(AquariumContext context)
        {
            this.context = context;
        }
        public async Task<List<Booking>> GetBookingForEmployee(Userr employee)
        {
            return await context.Bookings
                .Where(b => b.Employee.Id == employee.Id)
                .ToListAsync();
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            return await context.Bookings.Include(b => b.Employee).ToListAsync();
        }

        public async Task AddBooking(Booking booking)
        {
            if (booking.BookingDate < DateTime.Now)
            {
                throw new ArgumentException("Booking date cannot be in the past.");
            }
            context.Bookings.Add(booking);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBooking(Booking booking)
        {
            var existingBooking = await context.Bookings.FindAsync(booking.Id);
            if (existingBooking == null)
            {
                throw new ArgumentException("Booking with the specified ID does not exist.");
            }
            if (booking.BookingDate < DateTime.Now)
            {
                throw new ArgumentException("Booking date cannot be in the past.");
            }
            existingBooking.BookingDate = booking.BookingDate;
            existingBooking.UserEmployeeId = booking.UserEmployeeId;
            existingBooking.Tickets = booking.Tickets;
            await context.SaveChangesAsync();
        }
    }
}
