using Domain.Interfaces;

namespace Domain.Discounts;

public class FixedDiscount : IDiscount
{
    private readonly decimal _value;
    
    public FixedDiscount(decimal value)
    {
        _value = value;
    }
    
    public async Task<decimal> apply(decimal orderAmount)
    {
        if (_value > orderAmount)
            throw new InvalidOperationException("Desconto não pode ser maior que o valor do pedido.");
        var total = orderAmount - _value;

        return total;
    }
}