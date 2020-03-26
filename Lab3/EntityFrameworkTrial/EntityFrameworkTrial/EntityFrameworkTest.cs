using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTrial
{
    class EntityFrameworkTest
    {
        public static void Create()
        {

            using (CarRentalContext context = new CarRentalContext())
            {
                Car car1 = new Car();
                car1.Status = 1;

                Car car2 = new Car();
                car2.Status = 0;

                car1.CurrentDistance = 15;
                car2.CurrentDistance = 90;

                Reservation res = new Reservation();

                res.Status = 0;
                res.Car = car1;

                context.Cars.Add(car1);
                context.Cars.Add(car2);
                context.Reservations.Add(res);
                context.SaveChanges();
            }
        }

        public static void Read()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var foundReservations = context.Reservations
                    .Where(r => r.Status == 0);

                foreach (Reservation r in foundReservations)
                {
                    Console.WriteLine(r.ToString());
                }
            }
        }

        public static void Update(string registrationNumber, float xPos, float yPos)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var foundCar = context.Cars.Where(c => string.Equals(c.RegistrationNumber, registrationNumber)).FirstOrDefault();

                foundCar.XPosition = xPos;
                foundCar.YPosition = yPos;

                context.SaveChanges();
            }   
        }

        public static void Delete(string registrationNumber)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var foundCar = context.Cars.Where(c => string.Equals(c.RegistrationNumber, registrationNumber)).FirstOrDefault();
                context.Cars.Remove(foundCar);
                context.SaveChanges();
            }
        }

    }
}
