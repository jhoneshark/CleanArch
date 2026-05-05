using Domain.Entities;

namespace Aplication.Interfaces;

public interface IDiscountApplicationService
{
    Task<Order> ApplyFixedDiscountAsync(decimal amount, decimal discountValue);
    Task<Order> ApplyPercentageDiscountAsync(decimal amount, decimal percentage);
}