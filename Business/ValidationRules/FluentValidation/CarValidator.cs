using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo((short)1800);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.Description).MinimumLength(2);
        }
    }
}
