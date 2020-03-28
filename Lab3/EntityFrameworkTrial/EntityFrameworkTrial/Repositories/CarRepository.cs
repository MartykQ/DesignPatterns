using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EntityFrameworkTrial
{
    class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarRentalContext context) : base(context) { }

        public IList<Car> GetCarsInRadius(float x, float y, float radius)
        {
            string query = $"Select * from Cars where " +
                $"SQRT((XPosition - {x.ToString()})*(XPosition - {x.ToString()})" +
                $"+(YPosition-{y.ToString()})*(YPosition-{y.ToString()})) < {radius.ToString()}";
            return this.Find(query);
        }

        public IList<Car> GetLowBatteryCars()
        {
            string query = $"Select * from Cars where CurrentDistance > 150";
            return this.Find(query);
        }
    }
}
