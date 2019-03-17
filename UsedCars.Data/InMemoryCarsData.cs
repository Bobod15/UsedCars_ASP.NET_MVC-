using System.Collections.Generic;
using UsedCars.Core;
using System.Linq;

namespace UsedCars.Data
{
    public class InMemoryCarsData : ICarsData
    {
        readonly List<Car> cars;

        public InMemoryCarsData()
        {
            cars = new List<Car>()
            {
            new Car { ID = 1, Manifacturer = "Mercedes", Model = "Bentz", BuildYear = 1999, Price = 1000, OwnerInfo = "0881234567"},
            new Car { ID = 2, Manifacturer = "Opel", Model = "Insignia", BuildYear = 2016, Price = 20000, OwnerInfo = "0881234567" },
            new Car { ID = 3, Manifacturer = "asd", Model = "das", BuildYear = 2000, Price = 5000, OwnerInfo = "0881234567" },
            };

        }

        public Car GetById(int id)
        {
            return cars.SingleOrDefault(c => c.ID == id);
        }

        public Car AddNew(Car newCar)
        {
            cars.Add(newCar);
            newCar.ID = cars.Max(c => c.ID) + 1;
            return newCar;
        }

        public Car Update(Car updatedCar)
        {
            var car = cars.SingleOrDefault(c => c.ID == updatedCar.ID);
            if (car != null)
            {
                car.Manifacturer = updatedCar.Manifacturer;
                car.Model = updatedCar.Model;
                car.BuildYear = updatedCar.BuildYear;
                car.Price = updatedCar.Price;
                car.OwnerInfo = updatedCar.OwnerInfo;
            }
            return car;

        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Car> GetCarsByManifacturer(string manif = null)
        {   
            return from c in cars
                   where string.IsNullOrEmpty(manif) || c.Manifacturer.StartsWith(manif) || c.Model.Contains(manif)
                   orderby c.Manifacturer
                   select c; //beta tursachka
        }

        public Car DeleteCar(int id)
        {
            var car = cars.FirstOrDefault(c => c.ID == id);
            if(car != null)
            {
                cars.Remove(car);
            }
            return car;
        }

        public IEnumerable<Car> GetCarsByMultipleFields(string manifacturer, string model, string year, string owner)
        {
            throw new System.NotImplementedException();
        }
    }
}
