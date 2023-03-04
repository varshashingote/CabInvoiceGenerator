using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator248
{ 
        public class InvoiceGenerator
        {
            //Variable
            RideType rideType;
            private RideRepository rideRepository;

            //Constants
            private readonly double MINIMUM_COST_PER_KM;
            private readonly int COST_PER_TIME;
            private readonly double MINIMUM_FARE;

            /// <summary>
            /// Constructor to Create RideRepository instance
            /// </summary>

            public InvoiceGenerator(RideType rideType)
            {
                this.rideType = rideType;
                this.rideRepository = new RideRepository();
                try
                {
                    //If the Ride Type is Premium then Rates for Premium else for Normal  
                    if (rideType.Equals(RideType.PREMIUM))
                    {
                        this.MINIMUM_COST_PER_KM = 15;
                        this.COST_PER_TIME = 2;
                        this.MINIMUM_FARE = 20;
                    }
                    else if (rideType.Equals(RideType.NORMAL))
                    {
                        this.MINIMUM_COST_PER_KM = 10;
                        this.COST_PER_TIME = 1;
                        this.MINIMUM_FARE = 5;
                    }

                }
                catch (CabInvoiceCustomException)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_RIDETYPE, "Invalid ride type");
                }
            }

            //Function to Calculate Fare
            public double CalculateFare(double distance, int time)
            {
                double totalFare = 0;
                try
                {
                    //Calculating Total Fare
                    totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
                }
                catch (CabInvoiceCustomException)
                {
                    if (rideType.Equals(null))
                    {
                        throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_RIDETYPE, "Invalid ride type");
                    }
                    if (distance <= 0)
                    {
                        throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                    }
                    if (time < 0)
                    {
                        throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_TIME, "Invalid time");

                    }
                }
                return Math.Max(totalFare, MINIMUM_FARE);
            }

            public InvoiceSummary CalculateFare(Ride[] rides)
            {
                double totalFare = 0;
                try
                {
                    foreach (Ride ride in rides)
                    {
                        totalFare += this.CalculateFare(ride.distance, ride.time);

                    }
                }
                catch (CabInvoiceCustomException)
                {
                    if (rides == null)
                    {
                        throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.NULL_RIDES, "rides are null");
                    }

                }
                return new InvoiceSummary(rides.Length, totalFare);
            }

            //Function to Add Rides for Userid0. 
            public void AddRides(string userId, Ride[] rides)
            {
                RideRepository rideRepository = new RideRepository();
                try
                {
                    rideRepository.AddRide(userId, rides);
                }
                catch (CabInvoiceCustomException)
                {
                    if (rides == null)
                    {
                        throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.NULL_RIDES, "Rides are Null");
                    }
                }
            }
            public InvoiceSummary GetInvoiceSummary(string userId)
            {
                RideRepository rideRepository = new RideRepository();
                try
                {
                    return this.CalculateFare(rideRepository.GetRides(userId));
                }
                catch (CabInvoiceCustomException)
                {
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_USER_ID, "Invalid UserId");
                }
            }
        }
    }


















   