using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MovieTicketBook;


namespace MovieTicketBookTest
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void ValidConstructorArguments_NoExceptionThrown()
        {
            // Arrange
            string movieName = "Test Movie";
            int totalSeats = 100;
            decimal baseTicketPrice = 10.99m;

            // Act
            MovieTicketBooking booking = new MovieTicketBooking(movieName, totalSeats, baseTicketPrice);

            // Assert
            Assert.IsNotNull(booking);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidTotalSeats_ThrowsArgumentException()
        {
            // Arrange
            string movieName = "Test Movie";
            int totalSeats = 0;
            decimal baseTicketPrice = 10.99m;

            // Act
            MovieTicketBooking booking = new MovieTicketBooking(movieName, totalSeats, baseTicketPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidBaseTicketPrice_ThrowsArgumentException()
        {
            // Arrange
            string movieName = "Test Movie";
            int totalSeats = 100;
            decimal baseTicketPrice = -1.99m;

            // Act
            MovieTicketBooking booking = new MovieTicketBooking(movieName, totalSeats, baseTicketPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullMovieName_ThrowsArgumentNullException()
        {
            // Arrange
            string movieName = null;
            int totalSeats = 100;
            decimal baseTicketPrice = 10.99m;

            // Act
            MovieTicketBooking booking = new MovieTicketBooking(movieName, totalSeats, baseTicketPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyMovieName_ThrowsArgumentException()
        {
            // Arrange
            string movieName = "";
            int totalSeats = 100;
            decimal baseTicketPrice = 10.99m;

            // Act
            MovieTicketBooking booking = new MovieTicketBooking(movieName, totalSeats, baseTicketPrice);
        }

        [TestMethod]
        public void CancelBooking_ThrowsInvalidOperationException()
        {
            // Arrange
            string movieName = "Test Movie";
            int totalSeats = 100;
            decimal baseTicketPrice = 10.99m;
            MovieTicketBooking booking = new MovieTicketBooking(movieName, totalSeats, baseTicketPrice);

            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => booking.CancelBooking(101));
        }
    }
}
