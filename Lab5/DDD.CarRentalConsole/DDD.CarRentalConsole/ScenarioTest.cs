using DDD.CarRentalLib.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalConsole
{
    public class ScenarioTest
    {
        private ScenarioHelper _scenarioHelper;

        public ScenarioTest(ScenarioHelper scenarioHelper)
        {
            _scenarioHelper = scenarioHelper;
        }


        public void Test()
        {
            //Tworzymy 2 kierowcow
            Guid driver1ID = _scenarioHelper.CreateDriver("Szymon", "Kamień", "aa11");
            Guid driver2ID = _scenarioHelper.CreateDriver("Jan", "Kret", "bb22");

            //Tworzymy 2 samochody
            Guid car1ID = _scenarioHelper.CreateCar("KR1111");
            Guid car2ID = _scenarioHelper.CreateCar("KR22222");

            //Tworzymy 2 pracownikow
            Guid employee1 = _scenarioHelper.CreateEmployee("Dave", "Kowalski", "A01", JobPositionLevelDTO.Junior, "Manager", 13_000);
            Guid employee2 = _scenarioHelper.CreateEmployee("Marcin", "Podst", "B002", JobPositionLevelDTO.Senior, "CEO", 90_000);



            _scenarioHelper.ShowCars();
            _scenarioHelper.ShowDrivers();
            _scenarioHelper.ShowRentals();
            _scenarioHelper.ShowEmployees();
            _scenarioHelper.DrawSpace();
            //Rozpooczynamy 2 wypozyczenia
            Guid rental1 = _scenarioHelper.StartRental(driver1ID, car1ID, employee1);
            Guid rental2 = _scenarioHelper.StartRental(driver2ID, car2ID, employee2);

            _scenarioHelper.ShowCars();
            _scenarioHelper.ShowDrivers();
            _scenarioHelper.ShowRentals();
            _scenarioHelper.DrawSpace();


            //Konczymy 2 wypozyczenia
            _scenarioHelper.FinishRental(rental1, car1ID, driver1ID);
            _scenarioHelper.FinishRental(rental2, car2ID, driver2ID);

            _scenarioHelper.ShowCars();
            _scenarioHelper.ShowDrivers();
            _scenarioHelper.ShowRentals();
            _scenarioHelper.DrawSpace();

        }

    }
}
