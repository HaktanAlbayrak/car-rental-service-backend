using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private readonly ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    [ValidationAspect(typeof(CarValidator))]
    public IResult Add(Car car)
    {
        Car newCar = new();
        newCar.CreatedDate = DateTime.Now;
        newCar.CreatedBy = car.UserId;

        _carDal.Add(newCar);

        return new SuccessResult(Messages.CarAdded);
    }

    public IResult Delete(Car car)
    {
        _carDal.Delete(car);

        return new SuccessResult(Messages.CarDeleted);
    }

    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
    }


    public IDataResult<Car> GetById(int carId)
    {
        return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
    }

    public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == brandId));
    }

    public IDataResult<List<Car>> GetCarsByColorId(int colorId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
    }

    public IResult Update(Car car)
    {
        _carDal.Update(car);

        return new SuccessResult(Messages.CarUpdated);
    }
}
