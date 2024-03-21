using Tutorial3.Exceptions;
using IContainer = Tutorial3.Interfaces.IContainer;

namespace Tutorial3.Containers;

public abstract class Container : IContainer
{
    public static int ContainerCount { get; protected set; }
    public double CargoMass { get; protected set; } // kg
    public double Height { get; protected set; } 
    public double TareWeight { get; protected set; } // kg 
    public double Depth { get; protected set; }
    public double MaxPayload { get; protected set; } // kg
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
    
    public override string ToString()
    {
        return $"Serial number: {SerialNumber}\n" +
               $"Cargo mass: {CargoMass} kg\n" +
               $"Height: {Height} cm\n" +
               $"Tare weight: {TareWeight} kg\n" +
               $"Depth: {Depth} cm\n" +
               $"Max payload: {MaxPayload} kg\n";
    }
}