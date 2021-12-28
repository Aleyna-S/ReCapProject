using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            if (customer.UserId != 0)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.Added);
            }

            return new ErrorResult(Messages.Error);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.Id != 0)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.Deleted);
            }

            return new ErrorResult(Messages.Error);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
