using CarRental.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Persistence.Repositories
{
    public interface IDriverRepository : IRepository<Driver>
    {
        Driver GetDriverByLicense(string license);
    }
}
