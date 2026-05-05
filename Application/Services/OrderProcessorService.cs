using Domain.Entities;
using Domain.Interfaces;
using Aplication.Interfaces;
using Application.DTOs;

namespace Application.Services;

public class OrderProcessorService : IOrderProcessorService
{
    private readonly IInventoryChecker _inventoryChecker;
    private readonly IPaymentProcessor _paymentProcessor;
    private readonly IOrderCalculator _orderCalculator;
    
    public OrderProcessorService(IInventoryChecker inventoryChecker, IPaymentProcessor paymentProcessor, IOrderCalculator orderCalculator)
    {
        _inventoryChecker = inventoryChecker;
        _paymentProcessor = paymentProcessor;
        _orderCalculator = orderCalculator;
    }

    public async Task ProcessOrderAsync(OrderRequestDTO requestDto)
    {
        var order = new Order(requestDto.Amount);
        
        if (order == null) throw new ArgumentNullException(nameof(order), "O pedido não pode ser nulo.");
        
        await _inventoryChecker.check(order);
        await _paymentProcessor.process(order);
        await _orderCalculator.calculate(order);
        
        Console.WriteLine($"Pedido processado com sucesso! ID: {order.Uuid}, Valor: {order.OriginalAmount}");
    }
}