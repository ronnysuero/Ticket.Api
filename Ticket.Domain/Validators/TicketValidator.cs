using FluentValidation;
using Ticket.Domain.Models;

namespace Ticket.Domain.Validators
{
    public class TicketValidator : AbstractValidator<TicketModel>
    {
        public TicketValidator()
        {
            //Checking Required
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
        }
    }
}