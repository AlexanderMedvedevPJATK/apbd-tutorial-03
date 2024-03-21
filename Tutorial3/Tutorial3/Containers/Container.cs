using IContainer = Tutorial3.Interfaces.IContainer;

namespace Tutorial3.Containers;

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

    public virtual void Load(double cargoMass)
    {
        throw new NotImplementedException();
    }
}