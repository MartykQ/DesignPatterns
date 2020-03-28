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
            //float distance = Math.Sqrt(Math.Pow((), 2)
            Func<float, float, float, float, float> calculateDistance
                = (x1, y1, x2, y2) => (float)Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2),2));

            Expression<Func<Car, bool>> exp = car => (calculateDistance(car.XPosition, car.YPosition, x, y) <= radius);
            
            return this.Find(exp);
        }

        public IList<Car> GetLowBatteryCars()
        {
            Expression<Func<Car, bool>> exp = car => car.CurrentDistance > 180;
            return this.Find(exp);
        }
    }
}
