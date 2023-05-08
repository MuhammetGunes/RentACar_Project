﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var result = _rentalDal.GetAll(r => r.Id == rental.CarId && r.ReturnDate == null).Any();
            if (result==true)
            {
                return new ErrorResult(Messages.NotDeliveredRental);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.DeliveredRental);
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

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.CarsListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdatedRental);
        }

        public IResult RulesForAdding(Rental rental){
            var result = BusinessRules.Run(
               CheckIfRentDateIsBeforeToday(rental.RentDate),
               CheckIfReturnDateIsBeforeRentDate(rental.ReturnDate, rental.RentDate),
               CheckIfThisCarIsAlreadyRentedInSelectedDateRange(rental),
               CheckIfThisCarIsRentedAtALaterDateWhileReturnDateIsNull(rental),
               CheckIfThisCarHasBeenReturned(rental));
            if (result != null){return result;}
            return new SuccessResult();
        }




        private IResult CheckIfRentDateIsBeforeToday(DateTime rentDate)
        {
            if (rentDate.Date < DateTime.Now.Date)
            {
                return new ErrorResult(Messages.TheRentalDateCannotBeBeforeToday);
            }
            return new SuccessResult();
        }

        private IResult CheckIfThisCarIsRentedAtALaterDateWhileReturnDateIsNull(Rental rental)
        {
            var result = _rentalDal.Get(r =>
            r.CarId == rental.CarId
            && rental.ReturnDate == null
            && r.RentDate.Date > rental.RentDate.Date
            );

            if (result != null)
            {
                return new ErrorResult(Messages.CarReturnDateCannotBeBlank);
            }

            return new SuccessResult();
        }

        private IResult CheckIfThisCarHasBeenReturned(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);

            if (result != null)
            {
                if (rental.ReturnDate == null || rental.ReturnDate > result.RentDate)
                {
                    return new ErrorResult(Messages.CarNotReturned);
                }
            }
            return new SuccessResult();
        }

        private IResult CheckIfReturnDateIsBeforeRentDate(DateTime? returnDate, DateTime rentDate)
        {
            if (returnDate != null)
                if (returnDate < rentDate)
                {
                    return new ErrorResult(Messages.CarRentalDateNotExpired);
                }
            return new SuccessResult();
        }

        private IResult CheckIfThisCarIsAlreadyRentedInSelectedDateRange(Rental rental)
        {
            var result = _rentalDal.Get(r =>
            r.CarId == rental.CarId
            && (r.RentDate.Date == rental.RentDate.Date
            || (r.RentDate.Date < rental.RentDate.Date
            && (r.ReturnDate == null
            || ((DateTime)r.ReturnDate).Date > rental.RentDate.Date))));

            if (result != null)
            {
                return new ErrorResult(Messages.CarAlreadyRented);
            }
            return new SuccessResult();
        }
    }
}
