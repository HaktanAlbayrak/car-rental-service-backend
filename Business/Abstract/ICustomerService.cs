using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICustomerService
{
    IDataResult<List<Customer>> GetAll();
    IOperationResult Add(Customer customer);
    IOperationResult Delete(Customer customer);
    IOperationResult Update(Customer customer);
    IDataResult<Customer> GetById(int customerId);
}
