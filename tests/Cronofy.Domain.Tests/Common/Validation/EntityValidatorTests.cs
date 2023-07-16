using Cronofy.Domain.Common.Validation;
using Cronofy.Domain.Tests.Entities;
using Moq;

namespace Cronofy.Domain.Tests.Common.Validation;

[TestFixture]
public class EntityValidatorTests
{
    [Test]
    public void AggregatedBrokenRuleExceptionIsThrown_When_OneOrMoreRulesFail()
    {
        // Arrange
        var brokenRule = new Mock<IRule<TestEntity>>();
        brokenRule.Setup(x => x.CheckAsync(It.IsAny<TestEntity>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new TestRuleBrokenException());
        
        var sut = new TestEntityValidator(new List<IRule<TestEntity>> { brokenRule.Object });

        // Act & Assert
        Assert.ThrowsAsync<AggregatedBrokenRuleException>(async () =>
            await sut.ValidateAsync(new TestEntity(), new CancellationToken()));
    }
    
    [Test]
    public async Task EachRuleIsChecked()
    {
        // Arrange
        var rule1 = new Mock<IRule<TestEntity>>();
        var rule2 = new Mock<IRule<TestEntity>>();

        var sut = new TestEntityValidator(new List<IRule<TestEntity>>
        {
            rule1.Object,
            rule2.Object
        });

        // Act
        var testEntity = new TestEntity();
        await sut.ValidateAsync(testEntity, new CancellationToken());
        
        // Assert
        rule1.Verify(x => x.CheckAsync(
            It.Is<TestEntity>(y => y == testEntity), 
            It.IsAny<CancellationToken>()), Times.Once);
        
        rule2.Verify(x => x.CheckAsync(
            It.Is<TestEntity>(y => y == testEntity), 
            It.IsAny<CancellationToken>()), Times.Once);
    }

    private class TestEntityValidator : EntityValidator<TestEntity>
    {
        internal override IEnumerable<IRule<TestEntity>> Rules { get; }

        internal TestEntityValidator(IEnumerable<IRule<TestEntity>> rules)
        {
            Rules = rules;
        }
    }
    
    private class TestRuleBrokenException : BrokenRuleException
    {
        public override BrokenRuleSummary BrokenRuleSummary => new("TestRuleBroken", "Test rule is broken.");
    }
}