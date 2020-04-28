using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{   

    public enum JobPositionLevelDTO
    {
        Junior = 0,
        Regular = 1,
        Senior = 2
    }
    public class JobPositionDTO
    {
        public JobPositionLevelDTO JobPositionLevel {get; set; }
        public string JobTitle { get; set; }

    }
}
