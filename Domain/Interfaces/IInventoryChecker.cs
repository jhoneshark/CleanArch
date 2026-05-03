using Domain.Entities;

namespace Domain.Interfaces;

public interface IInventoryChecker
{
    Task <object?> check(Order order);
}