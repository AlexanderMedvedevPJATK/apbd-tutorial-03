using Tutorial3.Containers;

namespace Tutorial3.Ships;

public class ShipFactory
{
    public static int ShipCount { get; protected set; }
    public static List<Ship> Ships = new();
    
    public static Ship CreateShip()
    {
        double speed;
        do Console.Write("Enter speed: ");
        while (!double.TryParse(Console.ReadLine(), out speed) && speed <= 0);
        
        int maxContainers;
        do Console.Write("Enter max containers: ");
        while (!int.TryParse(Console.ReadLine(), out maxContainers) && maxContainers <= 0);
        
        double maxWeight;
        do Console.Write("Enter max weight: ");
        while (!double.TryParse(Console.ReadLine(), out maxWeight) && maxWeight <= 0);
        
        var ship = new Ship(++ShipCount, speed, maxContainers, maxWeight);
        Ships.Add(ship);
        return ship;
    }
    
    public static Ship GetSingleShip()
    {
        ListShips();
        
        int index;
        do Console.Write("Enter ship index from the list: ");
        while (!int.TryParse(Console.ReadLine(), out index) && (index < 0 || index > Ships.Count));
        
        return Ships[index - 1];
    }
    
    public static void ListShips()
    {
        Console.WriteLine("Ships: ");
        for (var i = 0; i < Ships.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Ships[i]}");
        }
    }
    public static void PrintShipInfo()
    {
        var ship = GetSingleShip();
        Console.WriteLine(ship);
        ship.ListContainers();
    }

    public static void DeleteShip()
    {
        Ships.Remove(GetSingleShip());
    }
    
    public static void LoadContainer()
    {
        var ship = GetSingleShip();
        var container = ContainerFactory.GetSingleContainer();
        ship.LoadContainer(container);
    }
    
    public static void UnloadContainer()
    {
        var ship = GetSingleShip();
        var container = ship.GetSingleContainer();
        ship.UnloadContainer(container);
    }
    
    public static void ReplaceContainer()
    {
        var ship = GetSingleShip();
        var oldContainer = ship.GetSingleContainer();
        var newContainer = ContainerFactory.GetSingleContainer();
        ship.ReplaceContainer(oldContainer, newContainer);
    }
    
    public static void TransferContainer()
    {
        var fromShip = GetSingleShip();
        var container = fromShip.GetSingleContainer();
        var toShip = GetSingleShip();

        fromShip.UnloadContainer(container);
        toShip.LoadContainer(container);
    }
}