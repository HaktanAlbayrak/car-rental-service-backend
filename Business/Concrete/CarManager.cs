using Business.Abstract;
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
    ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    public void Add(Car car)
    {
        // Araba ismi minimum 2 karakter olmalı
        if (car.Description.Length < 2)
        {
            throw new Exception("Car name must be at least 2 characters.");
        }

        // Araba günlük fiyatı 0'dan büyük olmalı
        if (car.DailyPrice <= 0)
        {
            throw new Exception("Car daily price must be greater than 0.");
        }

        _carDal.Add(car);
    }

    public void Delete(Car car)
    {
        _carDal.Delete(car);
    }

    public List<Car> GetAll()
    {
        return _carDal.GetAll();
    }


    public Car GetById(int id)
    {
        return _carDal.Get(c => c.Id == id);
    }

    public List<Car> GetCarsByBrandId(int brandId)
    {
        return _carDal.GetAll(b => b.BrandId == brandId);
    }

    public List<Car> GetCarsByColorId(int colorId)
    {
        return _carDal.GetAll(c => c.ColorId == colorId);
    }

    public void Update(Car car)
    {
        _carDal.Update(car);
    }
}
