using Aplication.Interfaces;
using Application.Services;
using Asp.Versioning;
using Domain.Entities;
using Infrastructure.ExternalServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Apiv2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProcessPayments : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ProcessPayment(Order order)
    {
        var paymentGateway = new MercadoPagoPaymentGateway();
        var paymentGatewayStripe = new StripePaymentGateway();
        var paymentProcess = new ProcessPaymentsServiceService(paymentGatewayStripe);
        await paymentProcess.Process(order);
        Console.WriteLine("Processando pagamento...");
        return Ok("iu");
    }
}
