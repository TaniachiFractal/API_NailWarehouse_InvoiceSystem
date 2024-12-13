using InvoiceSystem.Models.Products;
using InvoiceSystem.Services.Contracts.Models.Products;

namespace InvoiceSystem.Services.Models.Products
{
    /// <inheritdoc cref="IProductValidationService"/>
    public class ProductValidationService
        : DBObjectValidationService
        <ProductModel, AddProductModel, ProductModelValidator, AddProductModelValidator>,
        IProductValidationService
    {
    }
}
