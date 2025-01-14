using TrafficCourts.Common.OpenAPIs.OracleDataApi.v1_0;

namespace TrafficCourts.Citizen.Service.Validators.Rules;

/// <summary>Validates a Ticket Amount field - should be a parsable currency field, ie. '$110.00' or simply '120'.</summary>
public class TicketAmountValidRule : ValidationRule
{

    /// <summary>Validates a Ticket Amount field - should be a parsable currency field, ie. '$120.00' or simply '120'.</summary>
    public TicketAmountValidRule(Field field) : base(field)
    {
    }

    public override Task RunAsync()
    {
        if (Field.Value is not null)
        {
            float? currency = Field.GetCurrency();
            if (currency is null)
            {
                AddValidationError(String.Format(ValidationMessages.CurrencyInvalid, Field.Value));
            }
        } 
        return Task.CompletedTask;
    }
}
