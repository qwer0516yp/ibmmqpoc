namespace IBM.MQ.ProducerAPI;

public class ClosedCardRequest
{
    public required string CardNumber { get; set; }

    public required string Expiry { get; set; }

    public required string ProductType { get; set; }

    public required Metadata Metadata { get; set; }
}

public class Metadata
{
    public required string ClientId { get; set; }
    public required string EnqueueReason { get; set; }
}
