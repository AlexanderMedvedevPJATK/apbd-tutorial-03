using Tutorial3.Containers;
using Tutorial3.Exceptions;

namespace Tutorial3.Ships;

public class Ship
{
    public int Id { get; set; }
    public double Speed { get; protected set; }
    public int MaxContainers { get; protected set; }
    public double CurrWeight { get; protected set; } // tons
    public double MaxWeight { get; protected set; } // tons
    public List<Container> Containers { get; protected set; }
    
    public Ship(int id, double speed, int maxContainers, double maxWeight)
    {
        Id = id;
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
    
    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }
    
    public void UnloadContainer(Container container)
    {
        if (Containers.Contains(container))
        {
            CurrWeight -= container.CargoMass / 1000.0;
            Containers.Remove(container);
        } 
        else 
        {
            throw new ArgumentException("Container not found on the ship");
        }
    }
    
    public void UnloadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            UnloadContainer(container);
        }
    }
    
    public void ReplaceContainer(Container oldContainer, Container newContainer)
    {
        if (Containers.Contains(oldContainer))
        {
            CurrWeight -= oldContainer.CargoMass / 1000.0;
            CurrWeight += newContainer.CargoMass / 1000.0;
            Containers.Remove(oldContainer);
            Containers.Add(newContainer);
        }
        else
        {
            throw new ArgumentException("Container not found on the ship");
        }
    }
    
    public void ListContainers()
    {
        Console.WriteLine("Containers on the ship: ");
        for (var i = 0; i < Containers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Containers[i].SerialNumber}");
        }
    }
    
    public Container GetSingleContainer()
    {
        ListContainers();
        
        int index;
        do Console.Write("Enter container index from the list: ");
        while (!int.TryParse(Console.ReadLine(), out index) && index < 0 || index > Containers.Count);
        
        return Containers[index - 1];
    }
    
    public override string ToString()
    {
        return $"Ship: {Id}\n" +
               $"Speed: {Speed} knots\n" +
               $"Max containers: {MaxContainers}\n" +
               $"Current weight: {CurrWeight} tons\n" +
               $"Max weight: {MaxWeight} tons";
    }
}