using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public IOperationResult Add(User user)
    {
        if (_userDal.Quaryable().Any(u => u.Email == user.Email))
        {
            return new ErrorResult(Messages.ExistingUser);
        }
        _userDal.Add(user);
        return new SuccessResult(Messages.UserAdded);
    }

    public IOperationResult Delete(User user)
    {
        _userDal.Delete(user);
        return new SuccessResult(Messages.UserDeleted);
    }

    public IDataResult<List<User>> GetAll()
    {
        return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
    }

    public IDataResult<User> GetById(int userId)
    {
        return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
    }

    public IOperationResult Update(User user)
    {
        _userDal.Update(user);
        return new SuccessResult(Messages.UserUpdated);
    }
}
