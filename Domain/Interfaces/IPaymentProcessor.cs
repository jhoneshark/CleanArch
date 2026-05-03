using Domain.Entities;

namespace Domain.Interfaces;

public interface IPaymentProcessor
{
    Task <object?> process(Order order);
}