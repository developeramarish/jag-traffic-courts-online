using System.Text.RegularExpressions;
using TrafficCourts.Common.OpenAPIs.OracleDataApi.v1_0;

namespace TrafficCourts.Citizen.Service.Validators.Rules;

public class FieldMatchesRegexRule : ValidationRule
{
    private readonly string _pattern;
    private readonly string _reason;

    public FieldMatchesRegexRule(Field field, string pattern, string reason) : base(field)
    {
        this._pattern = pattern;
        this._reason = reason;
    }

    public override Task RunAsync()
    {
        if (Field.Value is null)
        {
            AddValidationError(String.Format(ValidationMessages.FieldIsBlankError, Field.TagName));
        }
        else if (!Regex.IsMatch(Field.Value, _pattern))
        {
            AddValidationError(_reason);
        }

        return Task.CompletedTask;
    }
}
