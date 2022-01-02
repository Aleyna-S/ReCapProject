using Business.Abstract;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Helpers.FileHelper;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Business;
using Business.Constants;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService

    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImages carImages)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImages.CarId));
            if (result != null)
            {
                return result;
            }
            carImages.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImages.Date = DateTime.Now;
            _carImageDal.Add(carImages);
            return new SuccessResult(Messages.AddedImages);
        }

        public IResult Delete(CarImages carImages)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImages.ImagePath);
            _carImageDal.Delete(carImages);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetCarsById(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImages>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImages> GetImagesById(int imageId)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile file, CarImages carImages)
        {
            carImages.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImages.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImages);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {

            List<CarImages> carImage = new List<CarImages>();
            carImage.Add(new CarImages { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImages>>(carImage);
        }
        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}

