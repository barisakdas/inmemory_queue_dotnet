namespace InMemoryQueue.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExcelController(IMessageService messageService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> CreateExcel()
    {
        var response = new
        {
            Status = await messageService.AddMessageToQueue()
        };

        return Ok(response);
    }
}