using Domain.Entities;

namespace Domain.Interfaces;

public interface IOrderCalculator
{
    Task <Object?> calculate(Order order);
}