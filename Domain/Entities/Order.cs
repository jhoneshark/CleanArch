using Domain.Interfaces;

namespace Domain.Entities;

public class Order
{
    public Guid Uuid { get; set; }
    public decimal OriginalAmount { get; set; }
    public decimal FinalAmount { get; private set; }
    public decimal DiscountApplied { get; private set; }
    public DateTime CreatedAt { get; private set; }

    // Construtor simples para inicializar o pedido
    public Order(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("O valor do pedido deve ser maior que zero.");

        Uuid = Guid.NewGuid();
        OriginalAmount = amount;
        FinalAmount = amount; // Inicialmente o total é o valor original
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Este é o ponto onde o Polimorfismo acontece.
    /// O método aceita qualquer classe que assine o contrato IDiscount.
    /// </summary>
    public async Task ApplyDiscountStrategy(IDiscount strategy)
    {
        if (strategy == null) return;

        // Delegamos o cálculo para a estratégia recebida
        // Não importa se é FixedDiscount ou PercentageDiscount
        this.FinalAmount = await strategy.apply(this.OriginalAmount);

        // Calculamos a diferença para fins de auditoria/log no banco
        this.DiscountApplied = this.OriginalAmount - this.FinalAmount;
    }
}