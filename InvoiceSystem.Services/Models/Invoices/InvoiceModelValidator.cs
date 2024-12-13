using InvoiceSystem.Models.Invoices;

namespace InvoiceSystem.Services.Models.Invoices
{
    /// <summary>
    /// Валидатор для <see cref="InvoiceModel"/>
    /// </summary>
    public class InvoiceModelValidator : UniqueIdValidator<InvoiceModel, AddInvoiceModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public InvoiceModelValidator() : base(new AddInvoiceModelValidator())
        {
        }
    }
}
