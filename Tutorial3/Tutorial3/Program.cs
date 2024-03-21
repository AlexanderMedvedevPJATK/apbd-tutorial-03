// See https://aka.ms/new-console-template for more information

using Tutorial3.Containers;
using Tutorial3.Ships;

while (true) {
    if (ShipFactory.Ships.Count == 0) {
        Console.WriteLine("List of container ships: None");
        Console.WriteLine("---------------------------");
    }
    else
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("List of container ships: ");
        ShipFactory.ListShips();
        Console.WriteLine("---------------------------");
    }
    if (ContainerFactory.Containers.Count == 0) {
        Console.WriteLine("List of containers: None");
        Console.WriteLine("---------------------------");
    }
    else
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine("List of containers: ");
        ContainerFactory.ListContainers();
        Console.WriteLine("---------------------------");
    }

    var actionIndex = 1;
    Console.WriteLine("Possible actions: ");
    if (ShipFactory.Ships.Count == 0 && ContainerFactory.Containers.Count == 0) 
    {
        Console.WriteLine($"{actionIndex++}. Create a ship");
    }
    else
    {
        Console.WriteLine($"{actionIndex++}. Create a ship");
        Console.WriteLine($"{actionIndex++}. Create a container");
        if (ShipFactory.Ships.Count == 0)
        {
            Console.WriteLine($"{actionIndex++}. Remove a container");
            Console.WriteLine($"{actionIndex++}. Unload a container");
            Console.WriteLine($"{actionIndex++}. Print container information");
        }
        else if (ContainerFactory.Containers.Count == 0)
        {
            Console.WriteLine($"{actionIndex++}. Remove a container ship");
            Console.WriteLine($"{actionIndex++}. Print ship and cargo information");
        }
        else
        {
            Console.WriteLine($"{actionIndex++}. Remove a container");
            Console.WriteLine($"{actionIndex++}. Unload a container");
            Console.WriteLine($"{actionIndex++}. Print containers information");
            Console.WriteLine($"{actionIndex++}. Remove a container ship");
            Console.WriteLine($"{actionIndex++}. Print ship and cargo information");
            Console.WriteLine($"{actionIndex++}. Load container on a ship");
            Console.WriteLine($"{actionIndex++}. Unload container from a ship");
            Console.WriteLine($"{actionIndex++}. Replace container on a ship with another container");
            Console.WriteLine($"{actionIndex++}. Transfer container between ships");
        }
    }
    Console.WriteLine($"{actionIndex++}. Exit");
    
    int action;
    do Console.Write("Enter action index: ");
    while (!int.TryParse(Console.ReadLine(), out action) && action < 1 || action > actionIndex);

    Console.WriteLine();
    
    if (ShipFactory.Ships.Count == 0 && ContainerFactory.Containers.Count == 0) 
    {
        switch (action)
        {
            case 1:
                ShipFactory.CreateShip();
                break;
            case 2:
                return;
        }
    }
    else
    {
        if (ShipFactory.Ships.Count == 0)
        {
            switch (action)
            {
                case 1:
                    ShipFactory.CreateShip();
                    break;
                case 2:
                    ContainerFactory.CreateContainer();
                    break;
                case 3:
                    ContainerFactory.DeleteContainer();
                    break;
                case 4:
                    ContainerFactory.UnloadContainer();
                    break;
                case 5:
                    ContainerFactory.ListContainers();
                    break;
                case 6:
                    return;
            }
        }
        else if (ContainerFactory.Containers.Count == 0)
        {
            switch (action)
            {
                case 1:
                    ShipFactory.CreateShip();
                    break;
                case 2:
                    ContainerFactory.CreateContainer();
                    break;
                case 3:
                    ShipFactory.DeleteShip();
                    break;
                case 4:
                    ShipFactory.PrintShipInfo();
                    break;
                case 5:
                    return;
            }
        }
        else
        {
            switch (action)
            {
                case 1:
                    ShipFactory.CreateShip();
                    break;
                case 2:
                    ContainerFactory.CreateContainer();
                    break;
                case 3:
                    ContainerFactory.DeleteContainer();
                    break;
                case 4:
                    ContainerFactory.UnloadContainer();
                    break;
                case 5:
                    ContainerFactory.ListContainers();
                    break;
                case 6:
                    ShipFactory.DeleteShip();
                    break;
                case 7:
                    ShipFactory.PrintShipInfo();
                    break;
                case 8:
                    ShipFactory.LoadContainer();
                    break;
                case 9:
                    ShipFactory.UnloadContainer();
                    break;
                case 10:
                    ShipFactory.ReplaceContainer();
                    break;
                case 11:
                    ShipFactory.TransferContainer();
                    break;
                case 12:
                    return;
            }
        }
    }
    Console.WriteLine();
}
