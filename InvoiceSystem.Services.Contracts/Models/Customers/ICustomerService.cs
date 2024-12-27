using InvoiceSystem.Models.Customers;

namespace InvoiceSystem.Services.Contracts.Models.Customers
{
    /// <summary>
    /// Сервис покупателей
    /// </summary>
    public interface ICustomerService : IDBobjectService<AddCustomerModel, CustomerModel, Customer>
    {
    }
}
