using CargoShip.Interfaces;

namespace CargoShip;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsPayloadHazardous { get;}
    private double FixedHazardousMaxPayloadMass { get;}
    private double FixedNonHazardousMaxPayloadMass { get;}

    public LiquidContainer(
        int height
        , double payloadMass
        , double weight
        , int depth
        , double maxPayloadMass
        , bool isPayloadHazardous) : base(height, payloadMass, weight, depth, maxPayloadMass)
    {
        SerialNumber = SerialNumberGenerator.GenerateSerialNumber();
        IsPayloadHazardous = isPayloadHazardous;
        FixedHazardousMaxPayloadMass = maxPayloadMass / 2;
        FixedNonHazardousMaxPayloadMass = maxPayloadMass * 0.9;
    }
    public LiquidContainer(
        int height
        , double weight
        , int depth
        , double maxPayloadMass
        , bool isPayloadHazardous) : base(height, weight, depth, maxPayloadMass)
    {
        SerialNumber = SerialNumberGenerator.GenerateSerialNumber();
        IsPayloadHazardous = isPayloadHazardous;
        FixedHazardousMaxPayloadMass = maxPayloadMass / 2;
        FixedNonHazardousMaxPayloadMass = maxPayloadMass * 0.9;
    }

    public new void LoadContainer(double payloadMass)
    {
        if (IsPayloadHazardous)
        {
            if (PayloadMass + payloadMass > FixedHazardousMaxPayloadMass)
            {
                WarningMessage();
                PayloadMass = FixedHazardousMaxPayloadMass;
                return;
            }
        }
        else
        {
            if (PayloadMass + payloadMass > FixedNonHazardousMaxPayloadMass)
            {
                WarningMessage();
                PayloadMass = FixedNonHazardousMaxPayloadMass;
                return;
            }
        }

        base.LoadContainer(payloadMass);
    }
    
    public void WarningMessage()
    {
        Console.WriteLine("Warning: System detected a hazardous operation in container: " + SerialNumber);
    }

    public override string ToString()
    {
        return "LiquidContainer: " + SerialNumber + " Height: " + Height + " PayloadMass: " + PayloadMass +
               " Weight: " + Weight + " Depth: " + Depth + " MaxPayloadMass: " + MaxPayloadMass +
               " IsPayloadHazardous: " + IsPayloadHazardous;
    }
}