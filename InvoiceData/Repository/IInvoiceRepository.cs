using InvoiceData.Models;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace InvoiceData.Repository
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice> GetByIdAsync(string id);
        Task AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task DeleteAsync(string id);
    }
}