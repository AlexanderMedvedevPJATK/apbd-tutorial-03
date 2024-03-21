using Tutorial3.Exceptions;
using IContainer = Tutorial3.Interfaces.IContainer;

namespace Tutorial3.Containers;

public abstract class Container : IContainer
{
    public static int ContainerCount { get; protected set; } = 0;
    public double CargoMass { get; protected set; }
    public double Height { get; protected set; }
    public double TareWeight { get; protected set; }
    public double Depth { get; protected set; }
    public double MaxPayload { get; protected set; }
    public string SerialNumber { get; protected set; } = string.Empty;

    protected Container(double cargoMass, double height, double tareWeight, double depth, double maxPayload)
    {
        CargoMass = cargoMass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;
    }

    public virtual void Unload()
    {
        TareWeight = 0;
    }

    public virtual void Load(double cargoMass, double multiplier = 1.0)
    {
        if (cargoMass + CargoMass > MaxPayload * multiplier)
        {
            throw new OverfillException("Cannot be loaded. Cargo mass exceeds max payload");
        }
    }
    
    // toString()
    public override string ToString()
    {
        return $"Serial number: {SerialNumber}\n" +
               $"Cargo mass: {CargoMass}\n" +
               $"Height: {Height}\n" +
               $"Tare weight: {TareWeight}\n" +
               $"Depth: {Depth}\n" +
               $"Max payload: {MaxPayload}\n";
    }
}