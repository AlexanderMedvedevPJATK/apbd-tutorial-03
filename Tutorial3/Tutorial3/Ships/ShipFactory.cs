using Tutorial3.Containers;

namespace Tutorial3.Ships;

public class ShipFactory
{
    public static int shipCount { get; protected set; }
    public static List<Ship> Ships { get; protected set; } = new();
    
    public static Ship CreateShip()
    {
        double speed;
        do Console.WriteLine("Enter speed: ");
        while (!double.TryParse(Console.ReadLine(), out speed) && speed <= 0);
        
        int maxContainers;
        do Console.WriteLine("Enter max containers: ");
        while (!int.TryParse(Console.ReadLine(), out maxContainers) && maxContainers <= 0);
        
        double maxWeight;
        do Console.WriteLine("Enter max weight: ");
        while (!double.TryParse(Console.ReadLine(), out maxWeight) && maxWeight <= 0);
        
        var ship = new Ship(++shipCount, speed, maxContainers, maxWeight);
        Ships.Add(ship);
        return ship;
    }
    // getSingeShip method
    public static Ship GetSingleShip()
    {
        ListShips();
        
        int index;
        do Console.WriteLine("Enter ship index from the list: ");
        while (!int.TryParse(Console.ReadLine(), out index) && index < 0 || index > Ships.Count);
        
        return Ships[index - 1];
    }
    
    
    // transfer container between ships
    public static void TransferContainer()
    {
        var fromShip = GetSingleShip();
        var container = fromShip.GetSingleContainer();
        var toShip = GetSingleShip();

        fromShip.UnloadContainer(container);
        toShip.LoadContainer(container);
    }
    
    public static void ListShips()
    {
        Console.WriteLine("Choose a ship: ");
        for (var i = 0; i < Ships.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Ships[i]}");
        }
    }
}