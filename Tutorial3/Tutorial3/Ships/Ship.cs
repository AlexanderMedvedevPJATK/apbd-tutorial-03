using Tutorial3.Containers;
using Tutorial3.Exceptions;

namespace Tutorial3.Ships;

public class Ship
{
    public double Speed { get; protected set; }
    public int MaxContainers { get; protected set; }
    public double CurrWeight { get; protected set; } // tons
    public double MaxWeight { get; protected set; } // tons
    public List<Container> Containers { get; protected set; }
    
    public Ship(double speed, int maxContainers, double maxWeight)
    {
        Speed = speed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        Containers = new List<Container>();
    }
    
    public void LoadContainer(Container container)
    {
        if (Containers.Count < MaxContainers && CurrWeight + container.CargoMass / 1000.0 <= MaxWeight)
        {
            CurrWeight += container.CargoMass / 1000.0;
            Containers.Add(container);
        }
        else if (Containers.Count >= MaxContainers)
        {
            throw new OverfillException("Cannot be loaded. Max containers reached");
        }
        else
        {
            throw new OverfillException("Cannot be loaded. Max weight reached");
        }
    }
}