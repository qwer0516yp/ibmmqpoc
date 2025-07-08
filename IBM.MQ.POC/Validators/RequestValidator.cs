using CommunityToolkit.Diagnostics;
using System.Text.RegularExpressions;

namespace IBM.MQ.ProducerAPI;

public static class RequestValidator
{
    public static void Validate(ClosedCardRequest request)
    {
        //required fields
        try
        {
            Guard.IsNotNull(request);
            Guard.IsNotWhiteSpace(request.CardNumber);
            Guard.IsNotWhiteSpace(request.Expiry);
            Guard.IsNotWhiteSpace(request.ProductType);
            Guard.IsNotNull(request.Metadata);
            Guard.IsNotWhiteSpace(request.Metadata.EnqueueReason);
        }
        catch (Exception e)
        {
            throw new ArgumentException("ERROR_REQUIRED_DATA_MISSING", e.Message);
        }

        //invalid value fields
        if (!Regex.IsMatch(request.CardNumber, @"^\d{16,19}$"))
        {
            throw new ArgumentException("INVALID CARDNUMBER");
        }
    }
}