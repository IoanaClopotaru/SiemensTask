using System.Globalization;
using SieMarket;

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");

var ioana = new Customer { Name = "Ioana" };
var tudor = new Customer { Name = "Tudor" };

var orders = new List<Order>
{
    new Order
    {
        Customer = ioana,
        Items = new List<OrderItem>
        {
            new OrderItem { ProductName = "Laptop", Quantity = 1, UnitPrice = 999m },
            new OrderItem { ProductName = "Mouse", Quantity = 2, UnitPrice = 25m }
        }
    },
    new Order
    {
        Customer = tudor,
        Items = new List<OrderItem>
        {
            new OrderItem { ProductName = "Monitor", Quantity = 2, UnitPrice = 300m }
        }
    },
    new Order
    {
        Customer = ioana,
        Items = new List<OrderItem>
        {
            new OrderItem { ProductName = "Keyboard", Quantity = 1, UnitPrice = 80m },
            new OrderItem { ProductName = "Mouse", Quantity = 1, UnitPrice = 25m }
        }
    }
};

foreach (var order in orders)
    Console.WriteLine($"Order subtotal: {order.Subtotal:C}, final: {order.CalculateFinalPrice():C}");

var topSpender = OrderService.GetCustomerWithHighestSpending(orders);
Console.WriteLine($"\nTop spending customer: {topSpender}");

var bestSellers = OrderService.GetPopularProducts(orders);
Console.WriteLine("\nPopular products:");
foreach (var product in bestSellers)
    Console.WriteLine($"  {product.ProductName}: {product.TotalQuantitySold}");
