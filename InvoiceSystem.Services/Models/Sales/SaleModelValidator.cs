using InvoiceSystem.Models.Sales;

namespace InvoiceSystem.Services.Models.Sales
{
    /// <summary>
    /// Валидатор для <see cref="SaleModel"/>
    /// </summary>
    public class SaleModelValidator : UniqueIdValidator<SaleModel, AddSaleModel>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public SaleModelValidator() : base(new AddSaleModelValidator())
        {
        }
    }
}
