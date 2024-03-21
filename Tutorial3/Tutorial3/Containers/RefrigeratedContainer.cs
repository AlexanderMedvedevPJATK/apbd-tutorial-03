namespace Tutorial3.Containers;

public class RefrigeratedContainer : Container
{
    public double Temperature { get; protected set; }
    public Product Product { get; protected set; }
    
    private static readonly Dictionary<Product, double> ProductTemperatures = new()
    {
        {Product.Banana, 13.3},
        {Product.Chocolate, 18.0},
        {Product.Fish, 2.0},
        {Product.Meat, -15.0},
        {Product.IceCream, -18.0},
        {Product.FrozenPizza, -30.0},
        {Product.Cheese, 7.2},
        {Product.Sausages, 5.0},
        {Product.Butter, 20.5},
        {Product.Eggs, 19}
    };
    
    public RefrigeratedContainer(
        double cargoMass,
        double height, 
        double tareWeight,
        double depth,
        double maxPayload,
        Product product,
        double temperature)
        : base(cargoMass, height, tareWeight, depth, maxPayload)
    {
        Product = product;
        if (temperature < ProductTemperatures[product])
        {
            throw new ArgumentException("Temperature is too low for the product");
        }
        SerialNumber = $"KON-C-{ContainerCount++}";
    }
    
}