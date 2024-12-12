using AutoMapper;
using InvoiceSystem.Database;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Services.Contracts.Models;

namespace InvoiceSystem.Services.Models.Customers
{
    /// <inheritdoc cref="ICustomerService"/>
    public class CustomerService : DBObjectService<AddCustomerModel, CustomerModel, Customer>, ICustomerService
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerService(InvcSysDBContext dbContext, IMapper mapper) : base(dbContext, dbContext.Customers, mapper)
        {
        }
    }
}
