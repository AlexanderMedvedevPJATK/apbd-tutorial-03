using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public class GasContainer : Container, IHazardNotifier
{
    
    public double Pressure { get; protected set; }
    // constructor
    public GasContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, double pressure) 
        : base(cargoMass, height, tareWeight, depth, maxPayload)
    {
        Pressure = pressure;
        SerialNumber = $"KON-G-{ContainerCount++}";
    }
    
    public override void Unload()
    {
        CargoMass = CargoMass * 0.05;
    }
    
    public void SendHazardNotification(string message, int number)
    {
        Console.WriteLine("Hazardous even occured: \n" +
                          message + "\n" +
                          "Container number: " + number);
    }
}