using CargoShip.Exceptions;

namespace CargoShip;

public class Ship(int maxSpeed, long maxContainerAmount, double maxContainerInTotalWeight)
{
    private List<Container> Containers { get; } = [];
    private int MaxSpeed { get; } = maxSpeed; // in knots
    private long MaxContainerAmount { get; } = maxContainerAmount;
    private double MaxContainerInTotalWeight { get; } = maxContainerInTotalWeight; // in tons


    public void PutContainer(Container container)
    {
        if (!IsFreeSpaceOnShipAvailable())
        {
            throw new ShipOverloadException("Ship reached max container amount");
        }

        if (isContainerOnShip(container))
        {
            throw new ContainerAlreadyOnShipException("Container already on board");
        }

        if (!DoesContainerFitInMaxWeight(container))
        {
            throw new ShipOutweighException("Container exceeds max weight");
        }

        Containers.Add(container);
        Containers.Sort(Comparer<Container>.Default);
        Console.WriteLine($"Added container {container.SerialNumber}");
    }

    public void PutContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            PutContainer(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        if (!isContainerOnShip(container))
        {
            throw new ContainerNotFoundException();
        }

        Containers.Remove(container);
    }

    public void SwitchContainer(string serialNumber, Container newContainer)
    {
        var oldContainer = FindContainerOnShip(serialNumber);

        if (oldContainer == null)
        {
            throw new ContainerNotFoundException();
        }
        
        Containers.Remove(oldContainer);
        Containers.Add(newContainer);
        Console.WriteLine($"Switched container {serialNumber} with {newContainer.SerialNumber}");
        Containers.Sort();
    }

    public void MoveContainerToAnotherShip(Container container, Ship newShip)
    {
        if (!isContainerOnShip(container))
        {
            throw new ContainerNotFoundException();
        }
        
        Console.WriteLine($"Trying to move container {container.SerialNumber} to chosen ship");

        newShip.PutContainer(container);
        Containers.Remove(container);

        Console.WriteLine($"Moved container {container.SerialNumber} to chosen ship");
    }

    public override string ToString()
    {
        if (Containers.Count == 0)
        {
            return "Ship: " + "MaxSpeed: " + MaxSpeed +
                   " MaxContainerAmount: " + MaxContainerAmount +
                   " MaxContainerWeight: " + MaxContainerInTotalWeight +
                   " Containers: None";
        }

        return "Ship: " + "MaxSpeed: " + MaxSpeed +
               " MaxContainerAmount: " + MaxContainerAmount +
               " MaxContainerWeight: " + MaxContainerInTotalWeight
               + " Containers:\n" + string.Join(",\n", Containers);
    }

    private Container? FindContainerOnShip(string serialNumber)
    {
        return Containers.FirstOrDefault(container => container.SerialNumber == serialNumber);
    }

    private bool isContainerOnShip(Container containerToCheck)
    {
        var container = FindContainerOnShip(containerToCheck.SerialNumber);
        return container != null;
    }

    private bool IsFreeSpaceOnShipAvailable()
    {
        return Containers.Count < MaxContainerAmount;
    }

    private bool DoesContainerFitInMaxWeight(Container container)
    {
        var currentContainerOnShipWeight = Containers.Sum(containerOnShip => containerOnShip.Weight);
        currentContainerOnShipWeight += MaxContainerInTotalWeight;
        var newWeightInTons = currentContainerOnShipWeight / 1000;


        return newWeightInTons <= MaxContainerInTotalWeight;
    }
}