using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : IBaseService<Rental>
    {
        IResult CheckReturnDate(int carId);
        IResult UpdateReturnDate(Rental rental);
    }
}
