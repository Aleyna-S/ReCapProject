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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {

            if (color.Name.Length < 2)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _colorDal.Add(color);

            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            try
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.Listed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Color>>((Messages.Error));
            }
        }

        public IResult Update(Color color)
        {
            try
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.Error);
            }
        }
    }
}
