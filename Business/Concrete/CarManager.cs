using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.Requests;
using Entities.DTOs.Responses;
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

    [SecuredOperation("car.add,admin")]
    [ValidationAspect(typeof(CarValidator))]
    public IResult Add(CreateCarRequest createCarRequest)
    {
        Car newCar = new();
        newCar.CreatedDate = DateTime.Now;
        newCar.CreatedBy = createCarRequest.UserId;
        newCar.BrandId = createCarRequest.BrandId;
        newCar.ColorId = createCarRequest.ColorId;
        newCar.DailyPrice = createCarRequest.DailyPrice;
        newCar.Description = createCarRequest.Description;
        newCar.ModelYear = createCarRequest.ModelYear;
        newCar.UserId = createCarRequest.UserId;

        _carDal.Add(newCar);

        return new SuccessResult(Messages.CarAdded);
    }

    public IResult Delete(Car car)
    {
        _carDal.Delete(car);

        return new SuccessResult(Messages.CarDeleted);
    }

    public IDataResult<List<GetAllCarResponse>> GetAll()
    {
        var cars = _carDal.GetAll();

        if (cars == null || !cars.Any())
        {
            return new ErrorDataResult<List<GetAllCarResponse>>(new List<GetAllCarResponse>(), Messages.NoCarIsAvailable);
        }

        var carResponses = cars.Select(car => new GetAllCarResponse
        {
            UserId = car.UserId,
            BrandId = car.BrandId,
            ColorId = car.ColorId,
            ModelYear = car.ModelYear,
            DailyPrice = car.DailyPrice,
            Description = car.Description,
            Id = car.Id,
            CreatedDate = car.CreatedDate,
            CarImages = car.CarImages?.Select(img => new CarImageDto
            {
                CarId = img.CarId,
                ImagePath = img.ImagePath
            }).ToList() ?? new List<CarImageDto>()
        }).ToList();

        return new SuccessDataResult<List<GetAllCarResponse>>(carResponses, Messages.CarsListed);
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
