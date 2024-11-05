using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private static List<Invoice> Invoices = new List<Invoice>();

        // GET: api/<InvoiceController>
        [HttpGet]
        public ActionResult<IEnumerable<Invoice>> Get()
        {
            return Ok(Invoices);
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public ActionResult<Invoice> Get(string id)
        {
            var invoice = Invoices.FirstOrDefault(i => i.InvoiceNumber == id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public ActionResult Post([FromBody] Invoice invoice)
        {
            if (invoice == null)
            {
                return BadRequest();
            }
            Invoices.Add(invoice);
            return CreatedAtAction(nameof(Get), new { id = invoice.InvoiceNumber }, invoice);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Invoice updatedInvoice)
        {
            var invoice = Invoices.FirstOrDefault(i => i.InvoiceNumber == id);
            if (invoice == null)
            {
                return NotFound();
            }
            invoice.DateIssued = updatedInvoice.DateIssued;
            invoice.DueDate = updatedInvoice.DueDate;
            invoice.BillTo = updatedInvoice.BillTo;
            invoice.Items = updatedInvoice.Items;
            invoice.Subtotal = updatedInvoice.Subtotal;
            invoice.SalesTax = updatedInvoice.SalesTax;
            invoice.TotalAmountDue = updatedInvoice.TotalAmountDue;
            return NoContent();
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var invoice = Invoices.FirstOrDefault(i => i.InvoiceNumber == id);
            if (invoice == null)
            {
                return NotFound();
            }
            Invoices.Remove(invoice);
            return NoContent();
        }
    }
}
