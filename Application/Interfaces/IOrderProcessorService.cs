using Domain.Entities;

namespace Aplication.Interfaces;

public interface IOrderProcessorService
{
    Task ProcessOrderAsync(Order order);
}