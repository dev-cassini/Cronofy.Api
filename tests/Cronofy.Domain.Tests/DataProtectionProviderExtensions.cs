using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Moq;

namespace Cronofy.Domain.Tests;

public static class DataProtectionProviderExtensions
{
    public static Mock<IDataProtectionProvider> Setup(
        this Mock<IDataProtectionProvider> dataProtectionProvider,
        string value)
    {
        var valueBytes = Encoding.Default.GetBytes(value);
        var protectedValue = $"test_protected_{value}";
        var protectedValueBytes = Encoding.Default.GetBytes(protectedValue);
        var dataProtector = new Mock<IDataProtector>();
        dataProtector.Setup(x => x.Protect(It.Is<byte[]>(y => y == valueBytes)))
            .Returns(protectedValueBytes);
        dataProtector.Setup(x => x.Unprotect(It.Is<byte[]>(y => y == protectedValueBytes)))
            .Returns(valueBytes);
        dataProtectionProvider.Setup(x => x.CreateProtector(It.IsAny<string>()))
            .Returns(dataProtector.Object);

        return dataProtectionProvider;
    }
}