using InvoiceSystem.Models.Customers;

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
        public CustomerModelValidator() : base(new AddCustomerModelValidator())
        {
        }
    }
}
