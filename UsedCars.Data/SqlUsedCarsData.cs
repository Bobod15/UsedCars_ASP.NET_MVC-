using System;
using System.Collections.Generic;
using System.Text;
using UsedCars.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UsedCars.Data
{
    public class SqlUsedCarsData : ICarsData
    {
        private readonly UsedCarsDbContext db;

        public SqlUsedCarsData(UsedCarsDbContext db)
        {
            this.db = db;
        }

        public Car AddNew(Car newCar)
        {
            db.Add(newCar);
            return newCar;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Car DeleteCar(int id)
        {
            var car = GetById(id);
            if(car != null)
            {
                db.Cars.Remove(car);
            }
            return car;
        }

        public Car GetById(int id)
        {
            return db.Cars.Find(id);
        }

        public IEnumerable<Car> GetCarsByManifacturer(string manif)
        {
            var query = from c in db.Cars
                        where string.IsNullOrEmpty(manif) || c.Manifacturer.StartsWith(manif) || c.Model.Contains(manif)
                        orderby c.Manifacturer
                        select c;
            return query;
        }

        public IEnumerable<Car> GetCarsByMultipleFields(string manifacturer, string model, string year, string owner)
        {
            int y;
            
            if (!Int32.TryParse(year, out y))
            {
                y = 0;
            }        

            var query = from c in db.Cars
                        where c.Manifacturer.Contains(manifacturer) ||
                                c.Model.Contains(model) ||
                                c.BuildYear == y ||
                                c.OwnerInfo.Contains(owner)
                        orderby c.Manifacturer
                        select c;
            
            return query;

        }

        public Car Update(Car updatedCar)
        {
            var entity = db.Cars.Attach(updatedCar);
            entity.State = EntityState.Modified;
            return updatedCar;
        }
    }


}
