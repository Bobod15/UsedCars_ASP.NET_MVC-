using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UsedCars.Core;

namespace UsedCars.Data
{
    public class UsedCarsDbContext : DbContext
    {
        public UsedCarsDbContext(DbContextOptions<UsedCarsDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
