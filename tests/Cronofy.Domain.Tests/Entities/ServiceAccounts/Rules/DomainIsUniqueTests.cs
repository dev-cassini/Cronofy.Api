using Cronofy.Domain.Entities.ServiceAccounts.Rules;
using Cronofy.Domain.Repositories;
using Moq;

namespace Cronofy.Domain.Tests.Entities.ServiceAccounts.Rules;

[TestFixture]
public class DomainIsUniqueTests
{
    [Test]
    public async Task CheckFails_WhenServiceAccountWithDomainAlreadyExists()
    {
        // Arrange
        var cancellationToken = new CancellationToken();
        var serviceAccount = await ServiceAccountBuilder.BuildAsync(cancellationToken);
        var serviceAccountRepository = new Mock<IServiceAccountRepository>();
        serviceAccountRepository.Setup(x => x.AnyAsync(
                It.Is<string>(y => y == serviceAccount.Domain), 
                It.Is<CancellationToken>(z => z == cancellationToken)))
            .ReturnsAsync(true);
        
        var sut = new DomainIsUnique(serviceAccountRepository.Object);

        //Act & Assert
        Assert.ThrowsAsync<DomainIsNotUniqueException>(async () => await sut.CheckAsync(serviceAccount, cancellationToken));
    }

    [Test]
    public async Task CheckPasses_WhenServiceAccountWithDomainDoesNotAlreadyExist()
    {
        // Arrange
        var cancellationToken = new CancellationToken();
        var serviceAccount = await ServiceAccountBuilder.BuildAsync(cancellationToken);
        var serviceAccountRepository = new Mock<IServiceAccountRepository>();
        serviceAccountRepository.Setup(x => x.AnyAsync(
                It.Is<string>(y => y == serviceAccount.Domain), 
                It.Is<CancellationToken>(z => z == cancellationToken)))
            .ReturnsAsync(false);
        
        var sut = new DomainIsUnique(serviceAccountRepository.Object);

        //Act & Assert
        Assert.DoesNotThrowAsync(async () => await sut.CheckAsync(serviceAccount, cancellationToken));
    }
}