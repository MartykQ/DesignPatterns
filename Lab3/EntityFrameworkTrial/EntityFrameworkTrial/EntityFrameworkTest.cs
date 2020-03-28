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
            Car car1 = new Car();
            car1.RegistrationNumber = "KBR";
            car1.XPosition = 120;
            car1.YPosition = 100;
            car1.Status = 1;
            car1.CurrentDistance = 15;

            Car car2 = new Car();
            car2.RegistrationNumber = "PO";
            car2.Status = 0;
            car2.XPosition = 12;
            car2.YPosition = 10;
            car2.CurrentDistance = 15;

            Reservation res1 = new Reservation();
            res1.Car = car1;
            res1.Status = 0;
            res1.ReservationDateTime = DateTime.Now;

            using ( ICarUnitOfWork uow = new CarUnitOfWork(new CarRentalContext()))
            {
                //uow.CarRepository.Insert(car1);
                uow.CarRepository.Insert(car2);

                uow.Commit();
            }
            using (IReservationUnitOfWork uow = new ReservationUnitOfWork(new CarRentalContext()))
            {
                uow.ReservationRepository.Insert(res1);
                uow.Commit();
            }

        }

        public static void Read()
        {
            using (IReservationUnitOfWork uow = new ReservationUnitOfWork(new CarRentalContext()))
            {
                var foundReservations = uow.ReservationRepository.GetNotUsedReservations();
                Console.WriteLine("Not used reservations: ");
                foreach (Reservation res in foundReservations)
                {
                    Console.WriteLine(res);
                }
            }

            
            using (ICarUnitOfWork uow = new CarUnitOfWork(new CarRentalContext()))
            {
                var lowBatteryCars = uow.CarRepository.GetLowBatteryCars();
                Console.WriteLine("Cars that need charging: ");
                foreach (Car c in lowBatteryCars)
                {
                    Console.WriteLine(c);
                }

                var carsInRadius = uow.CarRepository.GetCarsInRadius(23, 30, 50);
                Console.WriteLine("Cars in radius: ");
                foreach (Car c in carsInRadius)
                {
                    Console.WriteLine(c);
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
                // Deleting all reservations connected to the car with specified registration number
                var connectedReservations = context.Reservations.Where(r => string.Equals(r.Car.RegistrationNumber, registrationNumber));
                foreach (Reservation r in connectedReservations)
                {
                    context.Reservations.Remove(r);
                }
                var foundCar = context.Cars.Where(c => string.Equals(c.RegistrationNumber, registrationNumber)).FirstOrDefault();
                context.Cars.Remove(foundCar);
                context.SaveChanges();
            }
        }

    }
}
