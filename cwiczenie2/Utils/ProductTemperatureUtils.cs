namespace CargoShip;

public abstract class ProductTemperatureUtils
{
    private static readonly Dictionary<Product, double> ProductTemperatures = 
        PrepareProductTemperatures();
    
    
    public static double CalculateTemperature(Product product)
    {
      return ProductTemperatures[product];
    }

    private static Dictionary<Product, double> PrepareProductTemperatures()
    {
        return new Dictionary<Product, double>
        {
            { Product.Banana, 13.3d },
            { Product.Chocolate, 18d },
            { Product.Fish, 2d },
            { Product.Meat, -15d },
            { Product.IceCream, -18d },
            { Product.FrozenPizza, -30d },
            { Product.Cheese, 7.2d },
            { Product.Sausage, 5d },
            { Product.Butter, 20.5 },
            { Product.Eggs, 19d }
        };
    }
}