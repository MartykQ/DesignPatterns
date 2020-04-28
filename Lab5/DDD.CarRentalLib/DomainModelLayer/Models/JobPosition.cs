using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{ 
    
    public enum JobPositionLevel
    {
        Junior = 0,
        Regular = 1,
        Senior = 2
    }
    
    public class JobPosition : ValueObject
    {
        public JobPosition(string jobTitle, JobPositionLevel level)
        {
            JobTitle = jobTitle;
            Level = level;
        }

        public string JobTitle { get; protected set; }
        public JobPositionLevel Level { get; protected set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.JobTitle;
            yield return this.Level;
        }
    }
}
