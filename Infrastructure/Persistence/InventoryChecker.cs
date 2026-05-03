using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence;

public class InventoryChecker : IInventoryChecker
{
    public async Task<object?> check(Order order)
    {
        Console.WriteLine("Verificando estoque no banco de dados...");
        return null;
    }
}