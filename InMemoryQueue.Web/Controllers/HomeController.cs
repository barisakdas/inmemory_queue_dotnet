namespace InMemoryQueue.Web.Controllers
{
    public class HomeController(ILogger<HomeController> _logger, IProductService _productService, IMessageService _messageService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Products()
        {
            var products = await _productService.GetAllAsync();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> CreateExcel()
        {
            var response = new
            {
                Status = await _messageService.AddMessageToQueue()
            };

            return Json(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}