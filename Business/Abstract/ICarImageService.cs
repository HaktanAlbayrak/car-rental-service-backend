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
        Core.Utilities.Results.IResult Add(IFormFile file, CarImage carImage);
        Core.Utilities.Results.IResult Delete(CarImage carImage);
        Core.Utilities.Results.IResult Update(IFormFile file, CarImage carImage);
    }
}
