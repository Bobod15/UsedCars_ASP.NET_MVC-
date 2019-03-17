using System.Collections.Generic;
using UsedCars.Core;

namespace UsedCars.Data
{
    public interface ICarsData
    {
        IEnumerable<Car> GetCarsByManifacturer(string manif);
        IEnumerable<Car> GetCarsByMultipleFields(string manifacturer, string model, string year, string owner);
        Car GetById(int id);
        Car Update(Car updatedCar);
        Car AddNew(Car newCar);
        Car DeleteCar(int id);
        int Commit();
    }

}
