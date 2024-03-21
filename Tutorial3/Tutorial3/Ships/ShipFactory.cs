namespace Tutorial3.Ships;

public class ShipFactory
{
    // ship list
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
        
        var ship = new Ship(speed, maxContainers, maxWeight);
        Ships.Add(ship);
        return ship;
    }
}