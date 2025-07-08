using Microsoft.AspNetCore.Mvc;

namespace IBM.MQ.ProducerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClosedCardController : ControllerBase
{
    private readonly ILogger<ClosedCardController> _logger;
    private readonly IMqService _mqService;

    public ClosedCardController(ILogger<ClosedCardController> logger, IMqService mqService)
    {
        _logger = logger;
        _mqService = mqService;
    }

    [HttpPost(Name = "ClosedCard")]
    public async Task<IActionResult> Post([FromBody] ClosedCardRequest request)
    {
        try
        {
            RequestValidator.Validate(request);
            _logger.LogInformation("Processing ClosedCard Request {@Request}", request);

            //TODO: produce messages onto IBM MQ here, for simplicity, just the card number for now.
            _mqService.SendMessage(request.CardNumber);

            _logger.LogInformation("Producing ClosedCard message onto Account Closure queue, card {Card}", request.CardNumber);

            return new OkResult();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}