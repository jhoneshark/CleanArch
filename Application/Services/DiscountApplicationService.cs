using Aplication.Interfaces;
using Domain.Discounts;
using Domain.Entities;

namespace Application.Services;

public class DiscountApplicationService : IDiscountApplicationService
{
    public async Task<Order> ApplyFixedDiscountAsync(decimal amount, decimal discountValue)
    {
        var order = new Order(amount);
        var strategy = new FixedDiscount(discountValue);
        await order.ApplyDiscountStrategy(strategy);

        return order;
    }

    public async Task<Order> ApplyPercentageDiscountAsync(decimal amount, decimal percentage)
    {
        var order = new Order(amount);
        var strategy = new PercentageDiscount(percentage);
        await order.ApplyDiscountStrategy(strategy);

        return order;
    }
}