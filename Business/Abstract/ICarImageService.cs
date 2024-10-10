using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetImages();
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IDataResult<CarImage> GetImageById(int carImageId);
        IOperationResult Add(IFormFile file, CarImage carImage);
        IOperationResult Delete(CarImage carImage);
        IOperationResult Update(IFormFile file, CarImage carImage);
    }
}
