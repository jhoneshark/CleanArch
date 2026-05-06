using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.ExternalServices;

public class MercadoPagoPaymentGateway : IPaymentGateway
{
    public Task<object?> Pay(Order order)
    {
        Console.WriteLine("Efetuando Pagamento com Mercado Pago...");
        return Task.FromResult<object?>(new { Status = "Success", Gateway = "MercadoPago", Amount = order.OriginalAmount });
    }
}
