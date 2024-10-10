using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IOperationResult Add(User user);
        IOperationResult Delete(User user);
        IOperationResult Update(User user);
        IDataResult<User> GetById(int userId);
    }
}
