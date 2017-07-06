using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlaceBooking
{
    [TestFixture]
    public class PlaceRepositoryTests
    {
        [Test]
        public void PlaceIsBookedForUser()
        {
            PlaceRepository places = new PlaceRepository();
            User user = new User();
            Booking booking = places.Book("A", 1, user);
            Assert.AreEqual(user, booking.User);
        }

    }

    public class Booking
    {
        private readonly PlaceRepository _placeRepository;
        private readonly string _column;
        private readonly int _ordinal;
        private readonly User _user;

        public Booking(PlaceRepository placeRepository, string column, int ordinal, User user)
        {
            _placeRepository = placeRepository;
            _column = column;
            _ordinal = ordinal;
            _user = user;
        }

        public User User { get { return _user; } }

        public User BookedFor()
        {
            return User;
        }
    }

    public class User
    {
    }

    public class PlaceRepository
    {
        public Booking Book(string column, int ordinal, User user)
        {
            return new Booking(this, column, ordinal, user);
        }


    }
}
