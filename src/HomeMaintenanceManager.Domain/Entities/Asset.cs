namespace HomeMaintenanceManager.Domain.Entities;

public enum AssetStatus
{
    Active = 1,
    Inactive = 2,
    Retired = 3,
}

public class Asset
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public AssetStatus Status { get; private set; }

    public Asset(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Asset name cannot be empty.", nameof(name));

        Id = Guid.NewGuid();
        Name = name;
        Status = AssetStatus.Active;
    }
}
