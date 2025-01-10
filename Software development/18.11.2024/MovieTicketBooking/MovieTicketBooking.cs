using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBook
{
    public class MovieTicketBooking
    {
        static void Main(string[] args)
        {
        }

        public string MovieName { get; private set; }
        public int TotalSeats { get; private set; }
        public decimal BaseTicketPrice { get; private set; }
        public List<Ticket> BookedSeats { get; private set; } = new List<Ticket>();

        public MovieTicketBooking(string movieName, int totalSeats, decimal baseTicketPrice)
        {
            if (totalSeats <= 0)
                throw new ArgumentException("Total seats must be greater than zero.");
            if (baseTicketPrice < 0)
                throw new ArgumentException("Base ticket price must be positive.");
            if (string.IsNullOrEmpty(movieName))
                throw new ArgumentNullException("Movie name cannot be empty.");

            MovieName = movieName;
            TotalSeats = totalSeats;
            BaseTicketPrice = baseTicketPrice;
        }

        public void BookSeat(int seatNumber, bool isPremium)
        {
            if (seatNumber <= 0 || seatNumber > TotalSeats)
                throw new ArgumentException("Invalid seat number.");
            if (BookedSeats.Find(check => check.SeatNumber == seatNumber).Equals(seatNumber))
                throw new InvalidOperationException("Seat is already booked.");

            BookedSeats.Add(new Ticket(seatNumber, isPremium));


            if (BookedSeats.Count > TotalSeats)
                throw new InvalidOperationException("All seats are booked.");
        }

        public decimal CalculatePrice(int numberOfTickets, bool isPremium)
        {
            if (numberOfTickets <= 0)
                throw new ArgumentException("Number of tickets must be positive.");

            var price = BaseTicketPrice * numberOfTickets;


            if (isPremium)
                price += BaseTicketPrice * 0.2m;

            return Math.Round(price, 1);
        }

        public int GetAvailableSeats()
        {
            return TotalSeats - BookedSeats.Count;
        }

        public void CancelBooking(int seatNumber)
        {
            if (BookedSeats.Count == 0)
                throw new InvalidOperationException("No seats are booked.");
            if (!BookedSeats.Find(check => check.SeatNumber == seatNumber).SeatNumber.Equals(seatNumber))
                throw new InvalidOperationException("Seat is not booked.");
            else
                BookedSeats.Remove(BookedSeats.Find(check => check.SeatNumber == seatNumber));
        }

        public decimal GetAllSales()
        {
            decimal sum = 0.0m;
            foreach (var seat in BookedSeats)
            {
                sum += CalculatePrice(1, seat.IsPremium);
            }
            return 0;
        }
    }

    public class Ticket
    {
        public int SeatNumber { get; set; }
        public bool IsPremium { get; set; }

        public Ticket(int seatNumber, bool isPremium)
        {
            if (seatNumber <= 0)
                throw new ArgumentException("Seat number must be positive.");

            SeatNumber = seatNumber;
            IsPremium = isPremium;
        }
    }
}
