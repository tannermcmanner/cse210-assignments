class Order
{
    private const decimal DomesticShippingCost = 5m;
    private const decimal InternationalShippingCost = 35m;

    private readonly Customer _customer;
    private readonly List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal total = 0m;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += _customer.IsInUSA() ? DomesticShippingCost : InternationalShippingCost;
        return total;
    }

    public string GetPackingLabel()
    {
        List<string> lines = new List<string>();
        foreach (Product product in _products)
        {
            lines.Add($"{product.GetName()} ({product.GetProductId()})");
        }

        return string.Join("\n", lines);
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
