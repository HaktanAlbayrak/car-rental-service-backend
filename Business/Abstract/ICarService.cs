﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Requests;
using Entities.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<Car> GetById(int carId);
    IDataResult<List<GetAllCarResponse>> GetAll();
    IResult Add(CreateCarRequest createCarRequest);
    IResult Update(Car car);
    IResult Delete(Car car);
    IDataResult<List<Car>> GetCarsByBrandId(int brandId);
    IDataResult<List<Car>> GetCarsByColorId(int colorId);
}
