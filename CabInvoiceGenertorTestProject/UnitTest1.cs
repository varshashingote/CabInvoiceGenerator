
using CabInvoiceGenerator248;
using NUnit.Framework;

namespace CabInvoiceGenertorTestProject
{
   
    public class Tests
    {

        //InvoiceGenerator invoice = new InvoiceGenerator();

        [Test]
      //  [TestCase(0.5, 5, 5.5, RideType.NORMAL)]
       // [TestCase(0.5, 5, 8.5, RideType.PREMIUM)]
        [TestCase(2, 1, 4, RideType.NORMAL)]
        public void Given_Distance_And_Time_Return_TotalFare(int distance, int time, int expected, RideType rideType)
        {
            InvoiceGenerator invoice = new InvoiceGenerator();
            //Arrange
            invoice = new InvoiceGenerator();

            Ride ride = new Ride(distance, time, rideType);
            //Act
            double actual = invoice.CalculateFare(ride);

            //Assert
            Assert.AreEqual(actual, expected);

        }

        //[Test]
        //public void Given_Multiple_Rides_Return_TotalFare()
        //{
        //    InvoiceGenerator invoice = new InvoiceGenerator();
        //    //Arrage

        //    Ride[] rides = { new Ride(5, 2, RideType.NORMAL), new Ride(2, 3, RideType.PREMIUM) };
        //    InvoiceSummary expected = new InvoiceSummary(44, rides.Length);
        //    //Act
        //    //double actual= invoice.CalculateFare(rides);
        //    InvoiceSummary actual = invoice.CalculateFare(rides);
        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //    //expected.Equals(actual);  
        //}
    }
}




