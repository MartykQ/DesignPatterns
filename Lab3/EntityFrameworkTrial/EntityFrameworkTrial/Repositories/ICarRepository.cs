using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkTrial
{
    interface ICarRepository : IRepository<Car>
    {
        IList<Car> GetLowBatteryCars();
        IList<Car> GetCarsInRadius(float x, float y, float radius);

    }
}
