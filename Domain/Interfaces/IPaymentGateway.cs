using Domain.Entities;

namespace Domain.Interfaces;

public interface IPaymentGateway
{
    Task<object?> Pay(Order order);
}