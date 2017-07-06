using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Airline
{
    [TestFixture]
    public class FlightTests
    {
       	[Test]
       	public void SeatIsReservedForPassenger()
       	{
       	    FlightSeating seating = new FlightSeating();
       	    Passenger passenger = new Passenger();
       	    SeatReservation reservation = seating.Reserve("A", 1, passenger);
       	    Assert.AreEqual(passenger, reservation.Passenger);
       	}

    }

    public class SeatReservation
    {
        private readonly FlightSeating _flight;
        private readonly string _row;
        private readonly int _seatNumber;
        private readonly Passenger _passenger;

        public SeatReservation(FlightSeating flight, string row, int seatNumber, Passenger passenger)
        {
            _flight = flight;
            _row = row;
            _seatNumber = seatNumber;
            _passenger = passenger;
        }

        public Passenger Passenger { get { return _passenger;  } }

        public Passenger ReservedFor()
        {
            return Passenger;
        }
    }

    public class Passenger
    {
    }

    public class FlightSeating
    {
        public SeatReservation Reserve(string row, int seatNumber, Passenger passenger)
        {
            return new SeatReservation(this, row, seatNumber, passenger);
        }


    }
}
