using Domain.Interfaces;

namespace Domain.Discounts;

public class PercentageDiscount : IDiscount
{
    private readonly decimal _percentage;

    public PercentageDiscount(decimal percentage)
    {
        _percentage = percentage;

        if (_percentage <= 0 || _percentage > 100)
            throw new InvalidOperationException("Insira um percentual entre 1% e 100%");
    }
    
    public async Task<decimal> apply(decimal orderAmount)
    {
        var discountValue = orderAmount * _percentage / 100;
        
        var result = orderAmount - discountValue;
        
        return result;
    }
}