using Business.Abstract;
using Business.Constants;
using Core.Helpers.FileHelper;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CarImageManager : ICarImageService
{
    private readonly ICarImageDal _carImageDal;
    private readonly IFileHelperService _fileHelperService;

    public CarImageManager(ICarImageDal carImageDal, IFileHelperService fileHelperService)
    {
        _carImageDal = carImageDal;
        _fileHelperService = fileHelperService;
    }

    public Core.Utilities.Results.IResult Add(IFormFile file, CarImage carImage)
    {
        Core.Utilities.Results.IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));
        if (result.Success)
        {
            return result;
        }

        if (file.Length <= 0)
        {
            return new ErrorResult(Messages.InvalidFile);
        }

        var fileName = _fileHelperService.Upload(file, "Root/images");

        if (fileName == null)
        {
            return new ErrorResult(Messages.FileUploadError);
        }

        carImage.ImagePath = fileName;
        _carImageDal.Add(carImage);

        return new SuccessResult(Messages.ImageAdded);
    }

    public Core.Utilities.Results.IResult Delete(CarImage carImage)
    {
        var filePath = Path.Combine("Root/images", carImage.ImagePath);
        _fileHelperService.Delete(filePath);

        _carImageDal.Delete(carImage);
        return new SuccessResult(Messages.ImageDeleted);
    }

    public IDataResult<CarImage> GetImageById(int carImageId)
    {
        return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageId));
    }

    public IDataResult<List<CarImage>> GetImages()
    {
        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
    }

    public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
    {
        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
    }

    public Core.Utilities.Results.IResult Update(IFormFile file, CarImage carImage)
    {

        if (file.Length <= 0)
        {
            return new ErrorResult(Messages.InvalidFile);
        }


        var oldCarImage = _carImageDal.Get(c => c.Id == carImage.Id);
        if (oldCarImage != null)
        {

            var oldFilePath = Path.Combine("Root/images", oldCarImage.ImagePath);
            _fileHelperService.Delete(oldFilePath);
        }


        var newFileName = _fileHelperService.Upload(file, "Root/images");
        if (newFileName == null)
        {
            return new ErrorResult(Messages.FileUploadError);
        }


        carImage.ImagePath = newFileName;
        _carImageDal.Update(carImage);

        return new SuccessResult(Messages.ImageUpdated);
    }

    private Core.Utilities.Results.IResult CheckCarImageLimit(int carId)
    {
        var result = _carImageDal.GetAll(i => i.CarId == carId).Count();
        if (result > 5)
        {
            return new ErrorResult(Messages.CarImageLimitReached);
        }
        return new SuccessResult();
    }
}
