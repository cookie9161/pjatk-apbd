using CargoShip.Interfaces;

namespace CargoShip;

public class GasContainer : Container, IHazardNotifier
{
    private double FixedMinPayloadMass { get; set; }

    public GasContainer(int height,
        double payloadMass,
        double weight,
        int depth,
        double maxPayloadMass) : base(height, payloadMass, weight, depth, maxPayloadMass)
    {
        SerialNumber = SerialNumberGenerator.GenerateSerialNumber();
        FixedMinPayloadMass = CalculateMinPayloadMass();
    }
    public GasContainer(int height,
        int weight,
        int depth,
        int maxPayloadMass) : base(height, weight, depth, maxPayloadMass)
    {
        SerialNumber = SerialNumberGenerator.GenerateSerialNumber();
        FixedMinPayloadMass = CalculateMinPayloadMass();
    }

    public new void EmptyContainer()
    {
        FixedMinPayloadMass = CalculateMinPayloadMass();
        WarningMessage();
        PayloadMass = FixedMinPayloadMass;
        FixedMinPayloadMass = CalculateMinPayloadMass();
    }
    
    private double CalculateMinPayloadMass()
    {
        return PayloadMass * 0.05;
    }

    public void WarningMessage()
    {
        Console.WriteLine("Warning: System detected a hazardous operation in container: " + SerialNumber);
    }

    public override string ToString()
    {
        return "GasContainer: " + SerialNumber + " Height: " + Height + " PayloadMass: " + PayloadMass + " Weight: " +
               Weight + " Depth: " + Depth + " MaxPayloadMass: " + MaxPayloadMass;
    }
}