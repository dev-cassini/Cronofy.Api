using Cronofy.Domain.Enums;
using Microsoft.Extensions.Options;

namespace Cronofy.Domain.Entities.Applications.Validators;

public class ApplicationValidator : IValidateOptions<Application>
{
    public ValidateOptionsResult Validate(string? name, Application options)
    {
        if (options.Id == string.Empty)
        {
            return ValidateOptionsResult.Fail($"{nameof(Application)}.{nameof(Application.Id)} value is an empty string. Check environment variables are configured correctly.");
        }

        if (Enum.TryParse(options.DataCenter, out DataCenter _) is false)
        {
            return ValidateOptionsResult.Fail($"{nameof(Application)}.{nameof(Application.DataCenter)} value is not a valid data center. Check environment variables are configured correctly.");
        }

        if (options.ClientId == string.Empty)
        {
            return ValidateOptionsResult.Fail($"{nameof(Application)}.{nameof(Application.ClientId)} value is an empty string. Check environment variables are configured correctly.");
        }
        
        if (options.ClientSecret == string.Empty)
        {
            return ValidateOptionsResult.Fail($"{nameof(Application)}.{nameof(Application.ClientSecret)} value is an empty string. Check environment variables are configured correctly.");
        }
        
        return ValidateOptionsResult.Success;
    }
}