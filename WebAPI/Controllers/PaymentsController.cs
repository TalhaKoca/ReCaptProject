using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            Thread.Sleep(1000);
            var result = _paymentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _paymentService.GetByCustomerId(customerId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Payment payment)
        {
            var result = _paymentService.Add(payment);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Payment payment)
        {
            var result = _paymentService.Delete(payment);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Payment payment)
        {
            var result = _paymentService.Update(payment);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
