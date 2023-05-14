using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var carToRent = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (carToRent == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.DeliveredRental);
            }
            return new ErrorResult(Messages.NotDeliveredRental);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeletedRental);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.ListedRentals);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id==id),Messages.ListedRentals);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdatedRental);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.ListedRentals);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult RulesForAdding(Rental entity)
        {
            var result = BusinessRules.Run(
                CheckIfThisCarIsAlreadyRentedInSelectedDateRange(entity),
                CheckIfReturnDateIsBeforeRentDate(entity.ReturnDate, entity.RentDate)
                );
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(entity);
            return new SuccessResult("Ödeme Sayfasına Yönlendiriliyorsunuz.");

        }

        private IResult CheckIfThisCarIsAlreadyRentedInSelectedDateRange(Rental entity)
        {
            var result = _rentalDal.Get(r =>
            r.CarId == entity.CarId
            && (r.RentDate.Date == entity.RentDate.Date
            || (r.RentDate.Date < entity.RentDate.Date
            && (r.ReturnDate == null
            || ((DateTime)r.ReturnDate).Date > entity.RentDate.Date))));

            if (result != null)
            {
                return new ErrorResult(Messages.ThisCarIsAlreadyRentedInSelectedDateRange);
            }
            return new SuccessResult();
        }

        private IResult CheckIfThisCarHasBeenReturned(Rental entity)
        {
            var result = _rentalDal.Get(r => r.CarId == entity.CarId && r.ReturnDate == null);

            if (result != null)
            {
                if (entity.ReturnDate == null || entity.ReturnDate > result.RentDate)
                {
                    return new ErrorResult(Messages.ThisCarIsAlreadyRentedInSelectedDateRange);
                }
            }
            return new SuccessResult();




        }
        private IResult CheckIfReturnDateIsBeforeRentDate(DateTime? returnDate, DateTime rentDate)
        {
            if (returnDate != null)
                if (returnDate < rentDate)
                {
                    return new ErrorResult(Messages.ThisCarIsAlreadyRentedInSelectedDateRange);
                }
            return new SuccessResult();
        }
    }
}