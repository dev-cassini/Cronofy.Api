using Cronofy.Domain.Entities.ServiceAccounts.Rules;
using Cronofy.Domain.Entities.ServiceAccounts.Validators;
using Cronofy.Domain.Repositories;
using Moq;

namespace Cronofy.Domain.Tests.Entities.ServiceAccounts.Validators;

[TestFixture]
public class CreateValidatorTests
{
    [Test]
    public void DomainIsUniqueCheckIsIncludedInRules()
    {
        // Arrange
        var sut = new CreateValidator(Mock.Of<IServiceAccountRepository>());
        
        // Assert
        Assert.That(sut.Rules, Has.Exactly(1).TypeOf<DomainIsUnique>());
    }
}