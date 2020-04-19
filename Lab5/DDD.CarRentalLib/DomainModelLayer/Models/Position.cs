using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Position : ValueObject
    {
        public Position(double xPosition, double yPosition, DistanceUnit unit)
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
            this.Unit = unit;
        }
        // TODO: Dodac sprawdzanie/konwertowanie unitow
        public double XPosition { get; protected set; }
        public double YPosition { get; protected set; }
        public DistanceUnit Unit { get; protected set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.XPosition;
            yield return this.YPosition;
            yield return this.Unit;
        }

        public Distance CalculateDistance(Position destinationPoint)
        {
            double x1 = this.XPosition;
            double y1 = this.YPosition;

            double x2 = destinationPoint.XPosition;
            double y2 = destinationPoint.YPosition;

            double distanceKm = (Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

            Distance calculatedDistance = new Distance(distanceKm, DistanceUnit.Kilometers);

            return calculatedDistance;
        }
    }
}
