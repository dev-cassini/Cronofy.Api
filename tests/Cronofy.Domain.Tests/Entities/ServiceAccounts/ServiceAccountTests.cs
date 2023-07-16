using Cronofy.Domain.Events;
using Microsoft.AspNetCore.DataProtection;
using Moq;

namespace Cronofy.Domain.Tests.Entities.ServiceAccounts;

[TestFixture]
public class ServiceAccountTests
{
    [Test]
    public async Task DomainIsTrimmed()
    {
        // Arrange & Act
        var domainWithWhitespace = $"{Guid.NewGuid()}   ";
        var serviceAccount = await new ServiceAccountBuilder()
            .WithDomain(domainWithWhitespace)
            .BuildAsync();
        
        // Assert
        Assert.That(serviceAccount.Domain, Is.EqualTo(domainWithWhitespace.Trim()));
    }
    
    [Test]
    public async Task DomainIsLowercase()
    {
        // Arrange & Act
        var uppercaseDomain = $"{Guid.NewGuid()}".ToUpper();
        var serviceAccount = await new ServiceAccountBuilder()
            .WithDomain(uppercaseDomain)
            .BuildAsync();
        
        // Assert
        Assert.That(serviceAccount.Domain, Is.EqualTo(uppercaseDomain.ToLower()));
    }
    
    [Test]
    public async Task RefreshTokenIsProtected()
    {
        // Arrange & Act
        const string refreshToken = "test_refresh_token";
        var dataProtector = new Mock<IDataProtector>();
        var serviceAccount = await new ServiceAccountBuilder()
            .WithRefreshToken(refreshToken)
            .WithDataProtector(dataProtector)
            .BuildAsync();
        
        // Assert
        Assert.That(serviceAccount.ProtectedRefreshToken, Is.Not.EqualTo(refreshToken));
        dataProtector.Verify(x => x.Protect(It.IsAny<byte[]>()), Times.Once);
    }
    
    [Test]
    public async Task ServiceAccountCreatedEventIsAdded()
    {
        // Arrange & Act
        var serviceAccount = await new ServiceAccountBuilder().BuildAsync();
        
        // Assert
        Assert.That(serviceAccount.DomainEvents, Has.Exactly(1).TypeOf<ServiceAccountCreated>());

        var @event = serviceAccount.DomainEvents.Single(x => x is ServiceAccountCreated) as ServiceAccountCreated;
        Assert.That(@event!.Id, Is.EqualTo(serviceAccount.Id));
    }
}