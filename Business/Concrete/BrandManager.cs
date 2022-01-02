using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;


        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(Brand brand)
        {
            try
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Brand>>((Messages.Error));
            }
        }

        public IResult Update(Brand brand)
        {
            try
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.Error);
            }
        }
    }
}
