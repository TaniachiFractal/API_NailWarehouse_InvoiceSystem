using System;
using AutoMapper;
using InvoiceSystem.Database;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Services.Contracts.ModelServices;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Services.Models.Customers
{
    /// <inheritdoc cref="ICustomerService"/>
    public class CustomerService : ICustomerService
    {
        private readonly InvcSysDBContext dbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerService(InvcSysDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<Guid> Add(AddCustomerModel model, CancellationToken cancellationToken)
        {
            var item = mapper.Map<Customer>(model);
            item.CreatedDate = DateTimeOffset.Now;
            dbContext.Customers.Add(item);
            await dbContext.SaveChangesAsync(cancellationToken);
            return item.Id;
        }

        /// <inheritdoc/>
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await dbContext.Customers
                .FirstOrDefaultAsync(x => x.Id == id && x.DeletedDate == null, cancellationToken)
                ?? throw new NotFoundSupplierException(id);

            result.Name = string.Empty;
            result.Description = string.Empty;
            result.DeletedDate = DateTimeOffset.Now;
            dbContext.Customers.Update(result);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task Edit(AddCustomerModel model, CancellationToken cancellationToken)
        {
        }

        /// <inheritdoc/>
        public Task<IReadOnlyCollection<CustomerModel>> GetAll(CancellationToken cancellationToken)
        {
        }

        /// <inheritdoc/>
        public Task<CustomerModel> GetById(Guid id, CancellationToken cancellationToken)
        {
        }

        /// <inheritdoc/>
        public Task<Customer> GetIdByINN(string inn, CancellationToken cancellationToken)
        {
        }

        /// <inheritdoc/>
        public Task<Customer> GetIdByName(string name, CancellationToken cancellationToken)
        {
        }
    }
}
