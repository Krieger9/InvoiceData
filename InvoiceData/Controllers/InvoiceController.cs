using InvoiceData.Models;
using InvoiceData.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> Get()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            return Ok(invoices);
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> Get(string id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Invoice invoice)
        {
            if (invoice == null)
            {
                return BadRequest();
            }
            await _invoiceRepository.AddAsync(invoice);
            return CreatedAtAction(nameof(Get), new { id = invoice.InvoiceNumber }, invoice);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Invoice updatedInvoice)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            updatedInvoice.InvoiceNumber = id;
            await _invoiceRepository.UpdateAsync(updatedInvoice);
            return NoContent();
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            await _invoiceRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
