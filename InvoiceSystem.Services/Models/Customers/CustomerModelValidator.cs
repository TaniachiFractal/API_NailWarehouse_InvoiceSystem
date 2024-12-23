using InvoiceSystem.Models.Customers;
using InvoiceSystem.Repositories.Contracts.Customers;

namespace InvoiceSystem.Services.Models.Customers
{
    /// <summary>
    /// Валидатор для <see cref="CustomerModel"/>
    /// </summary>
    public class CustomerModelValidator : UniqueIdValidator<CustomerModel, AddCustomerModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public CustomerModelValidator(ICustomerReadRepository readRepository) : base()
        {
            AddCustomerModelValidator.RuleForINN(this, readRepository);
            AddCustomerModelValidator.RuleForAddress(this);
            AddCustomerModelValidator.RuleForName(this);
        }
    }
}
