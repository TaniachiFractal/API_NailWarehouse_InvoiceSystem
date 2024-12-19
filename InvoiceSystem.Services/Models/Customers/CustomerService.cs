using AutoMapper;
using InvoiceSystem.Database.Contracts.DBInterfaces;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Contracts.Customers;
using InvoiceSystem.Services.Contracts.Models.Customers;

namespace InvoiceSystem.Services.Models.Customers
{
    /// <inheritdoc cref="ICustomerService"/>
    public class CustomerService
        : DBObjectService<AddCustomerModel, CustomerModel, Customer>,
        ICustomerService
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerService(IMapper mapper, ICustomerReadRepository readRepository, ICustomerWriteRepository writeRepository, IUnitOfWork unitOfWork)
            : base(mapper, readRepository, writeRepository, unitOfWork)
        { }
    }
}
