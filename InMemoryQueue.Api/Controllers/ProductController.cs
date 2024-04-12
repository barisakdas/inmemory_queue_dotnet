namespace InMemoryQueue.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    // İlgili servisi içeriye alıyoruz.
    private readonly IProductService _service;

    // Servisi DI container içerisinde dahil ediyoruz.
    public ProductController(IProductService service)
       => _service = service;

    [HttpGet("getall")] // Yapılan işlemin endpointinin nasıl görüneceğini burada `getall` diyerek belirtiyoruz.
    public async Task<IActionResult> GetAllAsync()
    {
        // Servis üzerinden veriyi alıyoruz. Alınan bu veri bize Result<T> şeklinde döneceği için bunun yapılandırmasına ihtiyacımız var.
        var result = await _service.GetAllAsync();

        // Gelen verideki Result yapısının durumunu kontrol ederek ve ona uygun geri dönüş tipini (IActionResult) seçerek işlemi sonlandırıyoruz.
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        // Servis üzerinden veriyi alıyoruz. Alınan bu veri bize Result<T> şeklinde döneceği için bunun yapılandırmasına ihtiyacımız var.
        var result = await _service.GetByIdAsync(id);

        // Gelen verideki Result yapısının durumunu kontrol ederek ve ona uygun geri dönüş tipini (IActionResult) seçerek işlemi sonlandırıyoruz.
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("insert")]
    public async Task<IActionResult> InsertAsync(ProductDto model)
    {
        // Servis üzerinden veriyi alıyoruz. Alınan bu veri bize Result<T> şeklinde döneceği için bunun yapılandırmasına ihtiyacımız var.
        await _service.InsertAsync(model);

        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(ProductDto model)
    {
        // Servis üzerinden veriyi alıyoruz. Alınan bu veri bize Result<T> şeklinde döneceği için bunun yapılandırmasına ihtiyacımız var.
        await _service.UpdateAsync(model);

        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        // Servis üzerinden veriyi alıyoruz. Alınan bu veri bize Result<T> şeklinde döneceği için bunun yapılandırmasına ihtiyacımız var.
        await _service.DeleteAsync(id);

        return Ok();
    }
}