using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetById(int brandId);
        IDataResult<List<Brand>> GetAll();
        IOperationResult Add(Brand brand);
        IOperationResult Update(Brand brand);
        IOperationResult Delete(Brand brand);
    }
}
