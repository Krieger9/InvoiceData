using Azure.Messaging.ServiceBus;
using InvoiceData.Models;
using InvoiceData.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceData.Application
{
    public class InvoiceOrchestrator
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ServiceBusClient _serviceBusClient;
        private readonly string _queueName;

        public InvoiceOrchestrator(IInvoiceRepository invoiceRepository, ServiceBusClient serviceBusClient, string queueName)
        {
            _invoiceRepository = invoiceRepository;
            _serviceBusClient = serviceBusClient;
            _queueName = queueName;
        }

        public async Task ProcessInvoicesAsync(DateTime startDate, DateTime endDate)
        {
            var invoices = await GetInvoicesByDateRangeAsync(startDate, endDate);

            if (invoices != null)
            {
                foreach (var invoice in invoices)
                {
                    string messageBody;
                    if (invoice.TotalAmountDue > 1000)
                    {
                        messageBody = $"High-value invoice: {invoice.InvoiceNumber}";
                    }
                    else if (invoice.DueDate < DateTime.Now)
                    {
                        messageBody = $"Overdue invoice: {invoice.InvoiceNumber}";
                    }
                    else
                    {
                        messageBody = $"Normal invoice: {invoice.InvoiceNumber}";
                    }

                    await SendMessageToServiceBusAsync(messageBody);
                }
            }
        }

        private async Task<IEnumerable<Invoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var allInvoices = await _invoiceRepository.GetAllAsync();
            return allInvoices.Where(invoice => invoice.DateIssued >= startDate && invoice.DateIssued <= endDate);
        }

        private async Task SendMessageToServiceBusAsync(string messageBody)
        {
            ServiceBusSender sender = _serviceBusClient.CreateSender(_queueName);
            ServiceBusMessage message = new(messageBody);
            await sender.SendMessageAsync(message);
        }
    }
}
