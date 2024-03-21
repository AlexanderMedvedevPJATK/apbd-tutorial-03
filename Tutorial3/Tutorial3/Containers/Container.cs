using IContainer = Tutorial3.Interfaces.IContainer;

namespace Tutorial3;

public abstract class Container : IContainer
{
    public double CargoMass { get; protected set; }

    protected Container(double cargoMass)
    {
        CargoMass = cargoMass;
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }

    public void Load(double cargoMass)
    {
        throw new NotImplementedException();
    }
}