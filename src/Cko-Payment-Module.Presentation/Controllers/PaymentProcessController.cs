

using Cko_Payment_Module.Presentation.Helpers;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;

namespace Cko_Payment_Module.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentProcessController : ControllerBase
    {
        private readonly IPaymentProcessService paymentProcessService;

        public PaymentProcessController(IPaymentProcessService paymentProcessService)
        {
            this.paymentProcessService = paymentProcessService;
        }

        [HttpPost]
        public IActionResult CreatePaymentProcess([FromBody] PaymentProcessDto paymentProcessDto)
        {
            var invoice = this.paymentProcessService.CreatePayment(paymentProcessDto);

            return this.Ok(invoice);
        }
    }
}
