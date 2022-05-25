using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace SoapClientServiceReference.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculatorSoapClient _calculatorSoapClient;

        public CalculatorController(ILogger<CalculatorController> logger, ICalculatorSoapClient calculatorSoapClient)
        {
            _logger = logger;
            _calculatorSoapClient = calculatorSoapClient;
        }

        [HttpGet("Add/x/{x}/y/{y}")]
        public async Task<IActionResult> Add(double x, double y) => Ok(new { result = await _calculatorSoapClient.AddAsync(x, y) });

        [HttpGet("Divide/x/{x}/y/{y}")]
        public async Task<IActionResult> Divide(double x, double y) => Ok(new { result = await _calculatorSoapClient.DivideAsync(x, y) });

        [HttpGet("Multiply/x/{x}/y/{y}")]
        public async Task<IActionResult> Multiply(double x, double y) => Ok(new { result = await _calculatorSoapClient.MultiplyAsync(x, y) });

        [HttpGet("Subtract/x/{x}/y/{y}")]
        public async Task<IActionResult> Subtract(double x, double y) => Ok(new { result = await _calculatorSoapClient.SubtractAsync(x, y) });
    }
}