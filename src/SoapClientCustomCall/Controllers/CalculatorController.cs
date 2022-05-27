using Microsoft.AspNetCore.Mvc;
using SoapClientCustomCall.Helpers;

namespace SoapClientCustomCall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly string _url = "http://localhost:61668/Calculator.asmx";
        private readonly string _action = "http://tempuri.org/";

        private readonly ILogger<CalculatorController> _logger;
        private readonly ISoapHelper _soapHelper;

        public CalculatorController(ILogger<CalculatorController> logger, ISoapHelper soapHelper)
        {
            _logger = logger;
            _soapHelper = soapHelper;
        }

        [HttpGet("Add/x/{x}/y/{y}")]
        public async Task<IActionResult> Add(double x, double y) => Ok(new { result = _soapHelper.Send(_url, _action + "Add", FormatXml(x, y, "Add")) });

        [HttpGet("Divide/x/{x}/y/{y}")]
        public async Task<IActionResult> Divide(double x, double y) => Ok(new { result = _soapHelper.Send(_url, _action + "Divide", FormatXml(x, y, "Divide")) });

        [HttpGet("Multiply/x/{x}/y/{y}")]
        public async Task<IActionResult> Multiply(double x, double y) => Ok(new { result = _soapHelper.Send(_url, _action + "Multiply", FormatXml(x, y, "Multiply")) });

        [HttpGet("Subtract/x/{x}/y/{y}")]
        public async Task<IActionResult> Subtract(double x, double y) => Ok(new { result = _soapHelper.Send(_url, _action + "Subtract", FormatXml(x, y, "Subtract")) });


        private string FormatXml(double x, double y, string method)
        {
            return $@"<soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>
                        <soap:Body>
                            <{method} xmlns='http://tempuri.org/'>
                                <x>{x}</x>
                                <y>{y}</y>
                            </{method}>
                        </soap:Body>
                    </soap:Envelope>";
        }
    }
}