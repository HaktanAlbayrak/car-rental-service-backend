using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<Car> GetById(int carId);
    IDataResult<List<Car>> GetAll();
    IOperationResult Add(Car car);
    IOperationResult Update(Car car);
    IOperationResult Delete(Car car);
    IDataResult<List<Car>> GetCarsByBrandId(int brandId);
    IDataResult<List<Car>> GetCarsByColorId(int colorId);
}
