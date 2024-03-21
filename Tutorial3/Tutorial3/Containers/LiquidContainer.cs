using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public class LiquidContainer : Container, IHazardNotifier
{

    public bool Hazardous { get; protected set; }

    public LiquidContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, bool hazardous) 
        : base(cargoMass, height, tareWeight, depth, maxPayload)
    {
        Hazardous = hazardous;
        SerialNumber = $"KON-L-{ContainerCount++}";
    }

    public void SendHazardNotification(string message, int number)
    {
        Console.Write("You're trying to perform a dangerous operation: \n" +
                          message + "\n" +
                          "Occured at container number: " + number + "\n" +
                          "Are you sure you want to proceed? (yes/no): ");
    }

    public override void Load(double cargoMass, double multiplier = 1.0)
    {
        if (Hazardous)
        {
            try
            {
                if (Hazardous) base.Load(cargoMass, 0.5);
                else base.Load(cargoMass, 0.9);
            }
            catch (OverfillException)
            {
                if (Hazardous)
                {
                    SendHazardNotification("Container storing hazardous cargo should only be filled up to 50%", 0);
                }
                else
                {
                    SendHazardNotification("Container storing non-hazardous cargo should only be filled up to 90%", 0);
                }

                var response = Console.ReadLine();
                if (response != null && response.ToLower() == "yes")
                {
                    base.Load(cargoMass);
                }
            }
        }
    }
}