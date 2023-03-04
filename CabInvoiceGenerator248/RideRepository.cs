using System.Collections.Generic;
using System;

namespace CabInvoiceGenerator248
{
    internal class RideRepository
    {
        //Dictionary to store Usrid and Rides in List
        Dictionary<string, List<Ride>> userRides = null;

        //Constructor to create Dictionary
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        //Function to Add Ride list to Specified Userid
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CabInvoiceCustomException)
            {
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }

        //Function to get Rides List as a Array for Specified UserId
        public Ride[] GetRides(string userId)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (Exception)
            {
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_USER_ID, "Invalid user ID");
            }
        }
    }
}

    