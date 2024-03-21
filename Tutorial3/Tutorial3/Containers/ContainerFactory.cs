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
            do Console.WriteLine("Enter cargo mass: ");
            while (!double.TryParse(Console.ReadLine(), out cargoMass) && cargoMass <= 0);

            double height;
            do Console.WriteLine("Enter height: ");
            while (!double.TryParse(Console.ReadLine(), out height) && height <= 0);
                    
            double tareWeight;
            do Console.WriteLine("Enter tare weight: ");
            while (!double.TryParse(Console.ReadLine(), out tareWeight));
                    
            double depth;
            do Console.WriteLine("Enter depth: ");
            while (!double.TryParse(Console.ReadLine(), out depth) && depth <= 0);
                    
            double maxPayload;
            do Console.WriteLine("Enter max payload: ");
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
                    do Console.WriteLine("Enter pressure: ");
                    while (!double.TryParse(Console.ReadLine(), out pressure) && pressure <= 0);
                    
                    var gasContainer = new GasContainer(cargoMass, height, tareWeight, depth, maxPayload, pressure);
                    Containers.Add(gasContainer);
                    return gasContainer;
                case 3:
                    Product product;
                    do Console.WriteLine("Enter product: ");
                    while (!Enum.TryParse(Console.ReadLine(), out product));
                    
                    double temperature;
                    do Console.WriteLine("Enter temperature: ");
                    while (!double.TryParse(Console.ReadLine(), out temperature));
                    
                    var refrigeratedContainer = new RefrigeratedContainer(cargoMass, height, tareWeight, depth, maxPayload, product, temperature);
                    Containers.Add(refrigeratedContainer);
                    return refrigeratedContainer;
            }

            return null;
        }

        
        public static void LoadContainer()
        {
            Console.WriteLine("Choose a container to load: ");
            for (var i = 0; i < Containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Containers[i]}");
            }
            
            int index;
            do Console.WriteLine("Enter container index from the list: ");
            while (!int.TryParse(Console.ReadLine(), out index) && index < 0 || index > Containers.Count);
            
            var container = Containers[index - 1];
            
            double cargoMass;
            do Console.WriteLine("Enter cargo mass: ");
            while (!double.TryParse(Console.ReadLine(), out cargoMass) && cargoMass <= 0);
            
            container.Load(cargoMass);
        }
    }
}