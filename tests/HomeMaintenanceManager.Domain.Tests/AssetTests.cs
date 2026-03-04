using HomeMaintenanceManager.Domain.Entities;

namespace HomeMaintenanceManager.Domain.Tests;

public class AssetTests
{
    [Fact]
    public void CreatingAsset_WithValidName_SetsActiveStatus()
    {
        const string name = "Dishwasher";

        var asset = new Asset(name: name);

        Assert.Equal(name, asset.Name);
        Assert.Equal(AssetStatus.Active, asset.Status);
        Assert.NotEqual(Guid.Empty, asset.Id);
    }

    [Fact]
    public void CreatingAsset_WithEmptyName_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Asset(name: ""));
    }
}
