namespace SieMarket;

public static class OrderService
{
    public static string? GetCustomerWithHighestSpending(List<Order> orders)
    {
        if (orders.Count == 0)
            return null;

        var totals = new Dictionary<string, decimal>();
        string? best = null;
        decimal max = 0;

        foreach (var order in orders)
        {
            string name = order.Customer.Name;
            if (!totals.ContainsKey(name))
                totals[name] = 0;
            totals[name] += order.CalculateFinalPrice();

            if (totals[name] > max)
            {
                max = totals[name];
                best = name;
            }
        }
        return best;
    }

    public static List<ProductSales> GetPopularProducts(List<Order> orders)
    {
        var quantities = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var order in orders)
        {
            foreach (var item in order.Items)
            {
                if (!quantities.ContainsKey(item.ProductName))
                    quantities[item.ProductName] = 0;
                quantities[item.ProductName] += item.Quantity;
            }
        }

        var result = new List<ProductSales>();
        foreach (var pair in quantities)
            result.Add(new ProductSales(pair.Key, pair.Value));

        result.Sort((a, b) => b.TotalQuantitySold.CompareTo(a.TotalQuantitySold));
        return result;
    }
}

public class ProductSales
{
    public string ProductName { get; }
    public int TotalQuantitySold { get; }

    public ProductSales(string productName, int totalQuantitySold)
    {
        ProductName = productName;
        TotalQuantitySold = totalQuantitySold;
    }
}
