using AutoMapper;
using InvoiceSystem.Models.Customers;
using InvoiceSystem.Models.Invoices;
using InvoiceSystem.Models.Products;
using InvoiceSystem.Models.Sales;

namespace InvoiceSystem.Services
{
    /// <summary>
    /// Профиль автомаппера для всех таблиц
    /// </summary>
    public class AppAutoMapperProfile : Profile
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AppAutoMapperProfile()
        {
            CreateMap<Customer, CustomerModel>(MemberList.Destination);
            CreateMap<AddCustomerModel, Customer>(MemberList.Destination);

            CreateMap<Sale, SaleModel>(MemberList.Destination);
            CreateMap<AddSaleModel, Sale>(MemberList.Destination);

            CreateMap<Product, ProductModel>(MemberList.Destination);
            CreateMap<AddProductModel, Product>(MemberList.Destination);

            CreateMap<Invoice, InvoiceModel>(MemberList.Destination);
            CreateMap<AddInvoiceModel, Invoice>(MemberList.Destination);
        }
    }
}
