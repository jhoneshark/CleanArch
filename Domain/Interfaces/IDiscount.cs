namespace Domain.Interfaces;

public interface IDiscount
{
    Task<decimal> apply(decimal orderAmount);
}