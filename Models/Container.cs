using CargoShip.Exceptions;
using static System.String;

namespace CargoShip;

public abstract class Container : IComparable<Container>
{
    public string SerialNumber { get; init; }
    public int Height { get; } // in cm
    public double PayloadMass { get; set; } // in kg
    public double Weight { get; } // in kg
    public int Depth { get; } // in cm

    protected Container
    (
        int height,
        double payloadMass,
        double weight,
        int depth,
        double maxPayloadMass
    )
    {
        SerialNumber = "Initial";
        Height = height;
        Weight = weight;
        Depth = depth;
        MaxPayloadMass = maxPayloadMass;
        if (payloadMass > maxPayloadMass)
        {
            throw new OverfillException("Container is overfilled");
        }
        PayloadMass = payloadMass;
    }

    public double MaxPayloadMass { get; } // in kg

    protected Container
    (
        int height,
        double weight,
        int depth,
        double maxPayloadMass
    )
    {
        SerialNumber = "Initial";
        Height = height;
        PayloadMass = 0;
        Weight = weight;
        Depth = depth;
        MaxPayloadMass = maxPayloadMass;
    }

    public void EmptyContainer()
    {
        if (PayloadMass > 0)
        {
            PayloadMass = 0;
        }
    }

    public void LoadContainer(double payloadMass)
    {
        if (PayloadMass + payloadMass > MaxPayloadMass)
        {
            throw new OverfillException("Container is overfilled");
        }

        PayloadMass += payloadMass;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Container container)
        {
            return false;
        }

        return container.SerialNumber == SerialNumber
               && container.Height == Height
               && Math.Abs(container.PayloadMass - PayloadMass) < 0.0001
               && Math.Abs(container.Weight - Weight) < 0.0001
               && container.Depth == Depth
               && Math.Abs(container.MaxPayloadMass - MaxPayloadMass) < 0.0001;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(SerialNumber, Height, PayloadMass, Weight, Depth, MaxPayloadMass);
    }

    public int CompareTo(Container? other)
    {
        if (other == null)
        {
            return 1; 
        }
        
        var classComparison = Compare(GetType().Name, other.GetType().Name, StringComparison.Ordinal);
        return classComparison != 0 ? classComparison : Compare(SerialNumber, other.SerialNumber, StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return "Container: " + SerialNumber + " Height: " + Height + " PayloadMass: " + PayloadMass + " Weight: " +
               Weight + " Depth: " + Depth + " MaxPayloadMass: " + MaxPayloadMass;
    }
}