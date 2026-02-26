namespace SieMarket;

public class Order
{
    private const decimal DiscountThreshold = 500m;
    private const decimal DiscountFactor = 0.9m;

    public required Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; } = new();

    public decimal Subtotal => Items.Sum(i => i.LineTotal);

    public decimal CalculateFinalPrice()
    {
        if (Subtotal > DiscountThreshold)
            return Subtotal * DiscountFactor;
        return Subtotal;
    }
}
