namespace CargoShip;

public class RefrigeratedContainer : Container
{
    private Product Product { get; }
    private double InternalTemperature { get; }

    public RefrigeratedContainer
    (
        int height, 
        double payloadMass, 
        double weight, 
        int depth,
        double maxPayloadMass,
        Product product) : base(height, payloadMass, weight, depth, maxPayloadMass
    )
    {
        SerialNumber = SerialNumberGenerator.GenerateSerialNumber();
        Product = product;
        InternalTemperature = ProductTemperatureUtils.CalculateTemperature(product);
    }
    public RefrigeratedContainer
    (
        int height, 
        double weight, 
        int depth,
        double maxPayloadMass,
        Product product) : base(height, weight, depth, maxPayloadMass
    )
    {
        SerialNumber = SerialNumberGenerator.GenerateSerialNumber();
        Product = product;
        InternalTemperature = ProductTemperatureUtils.CalculateTemperature(product);
    }

    public override string ToString()
    {
        return "RefrigeratedContainer: " + SerialNumber + 
               " Height: " + Height + 
               " PayloadMass: " + PayloadMass + 
               " Weight: " + Weight + 
               " Depth: " + Depth + 
               " MaxPayloadMass: " + MaxPayloadMass
               + " Product: " + Product
               + " InternalTemperature: " + InternalTemperature;
    }
}