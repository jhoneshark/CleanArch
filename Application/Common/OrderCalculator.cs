using Domain.Entities;
using Domain.Interfaces;

namespace Application.Common;

public class OrderCalculator : IOrderCalculator
{
    public async Task<object?> calculate(Order order)
    {
        Console.WriteLine("Calculando ordem...");
        return null;
    }
}