using FluentValidation;

namespace Digitalantiz.Modules.Ticketing.Application.Orders.CreateOrder;

internal sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
    }
}
