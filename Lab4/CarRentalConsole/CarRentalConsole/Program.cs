using System;
using CarRental.Interfaces;
using CarRental.Commands;
using CarRental.Persistence;
using CarRental.Models;
using CarRental.Persistence.UnitOfWorks;

namespace CarRentalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CarRentalContext context = new CarRentalContext();

            // clear database
            ClearDatabase(context);

            using (CarRentalUoW unitOfWork= new CarRentalUoW(context))
            {
                var scenarioHelper = new TestSuiteHelpers(unitOfWork);

                //car1
                int car1id = scenarioHelper.CreateCar1();
                int driver1id = scenarioHelper.CreateDriver1();

                int rentId = scenarioHelper.DriverRentCar(car1id, driver1id);
                scenarioHelper.GiveBackCar(car1id, driver1id, rentId);


            }
            Console.WriteLine("Finished!");

        }

        private static void ClearDatabase(CarRentalContext context)
        {
            // clear database
            
            context.Drivers.Clear();
            context.Cars.Clear();
            context.RentalViews.Clear();
            context.Reservations.Clear();



            context.SaveChanges();
        }
    }
}
