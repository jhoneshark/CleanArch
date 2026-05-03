using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.ExternalServices;

public class PaymentProcessor : IPaymentProcessor
{
    public async Task<object?> process(Order order)
    {
        Console.WriteLine($"Processando pagamento no valor de R$ {order.Amount}...");
        return null;
    }
}