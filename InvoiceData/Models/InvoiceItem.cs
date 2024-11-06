using Newtonsoft.Json;

namespace InvoiceData.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; } // Surrogate key

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        [JsonProperty("unit_price")]
        public decimal? UnitPrice { get; set; }

        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        public string? InvoiceId { get; set; } // Foreign key to Invoice
    }
}
