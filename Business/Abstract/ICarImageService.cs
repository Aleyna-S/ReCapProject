using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImages carImages);
        IResult Delete(CarImages carImages);
        IResult Update(IFormFile file, CarImages carImages);
        IDataResult<List<CarImages>> GetAll();
        IDataResult<List<CarImages>> GetCarsById(int carId);
        IDataResult<CarImages> GetImagesById(int imageId);
    }
}
