using Aplication.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ProcessPaymentsServiceService
{
    private readonly IPaymentGateway _paymentGateway;
    
    public ProcessPaymentsServiceService(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }
    
    public async Task<object?> Process(Order order)
    {
        await _paymentGateway.Pay(order);
        Console.WriteLine($"Processando pagamento via {_paymentGateway.GetType().Name} no valor de R$ {order.OriginalAmount}...");
        return null;
    }
}
