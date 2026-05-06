using System.Text.Json.Serialization;
using Domain.Interfaces;

namespace Domain.Entities;

public class Order
{
    public Guid Uuid { get; set; }
    public decimal OriginalAmount { get; set; }
    public decimal FinalAmount { get; private set; }
    public decimal DiscountApplied { get; private set; }
    public DateTime CreatedAt { get; private set; }

    // Construtor vazio necessário para o desserializador JSON
    public Order()
    {
        Uuid = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    // Construtor simples para inicializar o pedido
    public Order(decimal originalAmount) : this()
    {
        if (originalAmount <= 0)
            throw new ArgumentException("O valor do pedido deve ser maior que zero.");

        OriginalAmount = originalAmount;
        FinalAmount = originalAmount; // Inicialmente o total é o valor original
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
