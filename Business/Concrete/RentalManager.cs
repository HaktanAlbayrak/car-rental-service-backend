using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class RentalManager : IRentalService
{
    private readonly IRentalDal _rentalDal;
    private readonly ICarDal _carDal;

    public RentalManager(IRentalDal rentalDal, ICarDal carDal)
    {
        _rentalDal = rentalDal;
        _carDal = carDal;
    }

    public IOperationResult Add(Rental rental)
    {
        var car = _carDal.Get(c => c.Id == rental.CarId);
        // Arabanın mevcut durumunu kontrol et
        var activeRental = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);

        if (activeRental != null)
        {
            return new ErrorResult(Messages.CarIsAlreadyRented); // Araç zaten kiralanmışsa hata döndür
        }

        _rentalDal.Add(rental);
        return new SuccessResult(Messages.RentalAdded);
    }

    public IOperationResult Delete(Rental rental)
    {
        _rentalDal.Delete(rental);
        return new SuccessResult(Messages.RentalDeleted);
    }

    public IDataResult<List<Rental>> GetAll()
    {
        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
    }

    public IDataResult<Rental> GetById(int rentalId)
    {
        return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == rentalId));
    }

    public IOperationResult Update(Rental rental)
    {
        _rentalDal.Update(rental);
        return new SuccessResult(Messages.RentalUpdated);
    }
}
