namespace Tutorial3.Containers
{
    public class ContainerFactory
    {
        
        public static List<Container> Containers = new();
        
        public static Container? CreateContainer()
        {
            Console.WriteLine("What type of container would you like to create?");
            Console.WriteLine("1. Liquid Container");
            Console.WriteLine("2. Gas Container");
            Console.WriteLine("3. Refrigerated Container");
            int input;
            do Console.WriteLine("Enter a number (1-3): ");
            while (!int.TryParse(Console.ReadLine(), out input) && input < 1 || input > 3);
            
            double cargoMass;
            do Console.WriteLine("Enter cargo mass in kg: ");
            while (!double.TryParse(Console.ReadLine(), out cargoMass) && cargoMass <= 0);

            double height;
            do Console.WriteLine("Enter height in cm: ");
            while (!double.TryParse(Console.ReadLine(), out height) && height <= 0);
                    
            double tareWeight;
            do Console.WriteLine("Enter tare weight in kg: ");
            while (!double.TryParse(Console.ReadLine(), out tareWeight));
                    
            double depth;
            do Console.WriteLine("Enter depth in cm: ");
            while (!double.TryParse(Console.ReadLine(), out depth) && depth <= 0);
                    
            double maxPayload;
            do Console.WriteLine("Enter max payload in kg: ");
            while (!double.TryParse(Console.ReadLine(), out maxPayload) && maxPayload <= 0);
            
            switch (input)
            {
                case 1:
                    bool hazardous;
                    do Console.WriteLine("Is the cargo hazardous? (true/false): ");
                    while (!bool.TryParse(Console.ReadLine(), out hazardous));
                    
                    var liquidContainer = new LiquidContainer(cargoMass, height, tareWeight, depth, maxPayload, hazardous);
                    Containers.Add(liquidContainer);
                    return liquidContainer;
                case 2:
                    double pressure;
                    do Console.WriteLine("Enter pressure in atmospheres: ");
                    while (!double.TryParse(Console.ReadLine(), out pressure) && pressure <= 0);
                    
                    var gasContainer = new GasContainer(cargoMass, height, tareWeight, depth, maxPayload, pressure);
                    Containers.Add(gasContainer);
                    return gasContainer;
                case 3:
                    Product product;
                    Console.WriteLine("Enter product index from the list: ");
                    var products = Enum.GetNames(typeof(Product));
                    for (var i = 0; i < products.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {products[i]}");
                    }
                    int productIndex;
                    do Console.WriteLine("Enter product index from the list: ");
                    while (!int.TryParse(Console.ReadLine(), out productIndex) &&
                           productIndex < 0 || productIndex > products.Length);
                    product = (Product) Enum.Parse(typeof(Product), products[productIndex - 1]);
                    // above could be done with Enum.TryParse but I decided to make it easier for the user
                    // so that they don't have to enter the exact name of the product
                    
                    double temperature;
                    do Console.WriteLine("Enter temperature in Celsius: ");
                    while (!double.TryParse(Console.ReadLine(), out temperature));
                    
                    var refrigeratedContainer = new RefrigeratedContainer(cargoMass, height, tareWeight, depth, maxPayload, product, temperature);
                    Containers.Add(refrigeratedContainer);
                    return refrigeratedContainer;
            }

            return null;
        }

        
        public static void LoadContainer()
        {
            ListContainers();
            
            int index;
            do Console.WriteLine("Enter container index from the list: ");
            while (!int.TryParse(Console.ReadLine(), out index) && index < 0 || index > Containers.Count);
            
            double cargoMass;
            do Console.WriteLine("Enter cargo mass in kg: ");
            while (!double.TryParse(Console.ReadLine(), out cargoMass) && cargoMass <= 0);
            
            Containers[index - 1].Load(cargoMass);
        }
        
        public static Container GetSingleContainer()
        {
            ListContainers();
            
            int index;
            do Console.WriteLine("Enter container index from the list: ");
            while (!int.TryParse(Console.ReadLine(), out index) && index < 0 || index > Containers.Count);
            
            return Containers[index - 1];
        }
        
        public static List<Container> GetManyContainer()
        {
            ListContainers();
            
            var containerIndexes = new List<int>();
            Console.WriteLine("Enter container indexes from the list separated by space: ");
            var indexes = Console.ReadLine();
            if (indexes != null)
            {
                var splitIndexes = indexes.Split("\\s+");
                foreach (var index in splitIndexes)
                {
                    if (int.TryParse(index, out var i) && i > 0 && i <= Containers.Count)
                    {
                        containerIndexes.Add(i - 1);
                    }
                }
            }
            
            var containers = new List<Container>();
            foreach (var index in containerIndexes)
            {
                containers.Add(Containers[index - 1]);
            }

            return containers;
        }
        
        public static void ListContainers()
        {
            Console.WriteLine("Choose a container to load: ");
            for (var i = 0; i < Containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Containers[i]}");
            }
        }
    }
}