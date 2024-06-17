using Domain.Models;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.ReservationDate).NotNull();
            RuleFor(x => x.BusinessOwnerUserId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().NotNull().Length(2,50);
        }
    }
}
