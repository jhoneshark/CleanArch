using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.ExternalServices;

public class StripePaymentGateway : IPaymentGateway
{
    public Task<object?> Pay(Order order)
    {
        Console.WriteLine("Efetuando Pagamento com Stripe...");
        return Task.FromResult<object?>(new { Status = "Success", Gateway = "Stripe", Amount = order.OriginalAmount });
    }
}