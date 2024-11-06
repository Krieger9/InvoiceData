    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice> GetByIdAsync(string id);
        Task AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task DeleteAsync(string id);
    }
    