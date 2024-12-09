using InvoiceSystem.Models.Customers;

namespace InvoiceSystem.Services.Contracts.ModelServices
{
    /// <summary>
    /// Сервис <see cref="Customer"/>
    /// </summary>
    public interface ICustomerService : IDBobjectService
    {
        /// <summary>
        /// Получить ID покупателя по имени
        /// </summary>
        Task<Customer> GetIdByName(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Получить ID покупателя по ИНН
        /// </summary>
        Task<Customer> GetIdByINN(string inn, CancellationToken cancellationToken);
    }
}
