namespace HomeMaintenanceManager.Domain.Entities;

public class Asset
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Asset(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Asset name cannot be empty.", nameof(name));

        Id = Guid.NewGuid();
        Name = name;
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("New asset name cannot be empty.", nameof(newName));

        Name = newName;
    }
}
