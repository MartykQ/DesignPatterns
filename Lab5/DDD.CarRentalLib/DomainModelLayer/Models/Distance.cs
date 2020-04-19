using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Models;


namespace DDD.CarRentalLib.DomainModelLayer.Models
{

    public enum DistanceUnit
    {
        Kilometers = 0,
        Meters = 1,
        Centimeters = 2

    }
    public class Distance : ValueObject
    {
        public Distance(double value, DistanceUnit unit)
        {
            this.Value = value;
            this.Unit = unit;
        }

        public double Value { get; protected set; }
        public DistanceUnit Unit { get; protected set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
            yield return this.Unit;
        }

        public int Compare(Distance d)
        {
            if (this.Unit == d.Unit)
            {
                return this.Value.CompareTo(d.Value);
            } else
                throw new Exception("Distnaces in different units!");
           
        }

        public static bool operator <(Distance d, Distance d2)
        {
            return d.Compare(d2) < 0;
        }

        public static bool operator >(Distance d, Distance d2)
        {
            return d.Compare(d2) > 0;
        }

        public static bool operator <=(Distance d, Distance d2)
        {
            return d.Compare(d2) <= 0;
        }
        public static bool operator >=(Distance d, Distance d2)
        {
            return d.Compare(d2) >= 0;
        }

        public static Distance ToKilometers(Distance d)
        {
            if (d.Unit == DistanceUnit.Kilometers)
            {
                return d;
            }
            else if (d.Unit == DistanceUnit.Meters)
            {
                d.Value /= 1000;
                d.Unit = DistanceUnit.Kilometers;
                return d;
            }
            else if (d.Unit == DistanceUnit.Centimeters)
            {
                d.Value /= 100000;
                d.Unit = DistanceUnit.Kilometers;
                return d;
            }
            else
                throw new Exception("Unsupported distance unit!");
        }

    }
}
