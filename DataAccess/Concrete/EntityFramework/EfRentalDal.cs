using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from ca in context.Cars
                             join re in context.Rentals
                                 on ca.Id equals re.CarId
                             join cu in context.Customers
                                 on re.CustomerId equals cu.Id
                             join u in context.Users
                                 on cu.UserId equals u.Id
                             join br in context.Brands
                                 on ca.BrandId equals br.Id
                             join co in context.Colors
                                 on ca.ColorId equals co.Id

                             select new CarRentalDetailDto
                             {
                                 RentalId = re.Id,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 CarName = ca.Description,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.DailyPrice,
                                 CustomerCompanyName = cu.CompanyName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}
