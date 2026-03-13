namespace HomeMaintenanceManager.Application.Tests.Assets.Commands;

using HomeMaintenanceManager.Application.Assets;
using HomeMaintenanceManager.Application.Assets.Commands;
using HomeMaintenanceManager.Domain.Entities;
using Moq;

public class CreateAssetTest
{
    [Fact]
    public async Task Execute_WithValidName_AddsAssetToRepository()
    {
        var repositoryMock = new Mock<IAssetRepository>();
        var command = new CreateAsset(repositoryMock.Object);
        var name = "Washing Machine";

        var id = command.Execute(name: name);

        repositoryMock.Verify(r => r.AddAsync(It.IsAny<Asset>()), Times.Once);
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}
