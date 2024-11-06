using Newtonsoft.Json;

namespace InvoiceData.Models
{
    public class Invoice
    {
        [JsonProperty("invoice_number")]
        public string? InvoiceNumber { get; set; }

        [JsonProperty("date_issued")]
        public DateTime? DateIssued { get; set; }

        [JsonProperty("due_date")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("bill_to")]
        public Customer? BillTo { get; set; }

        [JsonProperty("items")]
        public List<InvoiceItem>? Items { get; set; }

        [JsonProperty("subtotal")]
        public decimal Subtotal { get; set; }

        [JsonProperty("sales_tax")]
        public decimal SalesTax { get; set; }

        [JsonProperty("total_amount_due")]
        public decimal TotalAmountDue { get; set; }
    }
}
