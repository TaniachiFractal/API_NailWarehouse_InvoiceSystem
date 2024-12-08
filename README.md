# Web API системы накладных Склада Гвоздей
### Маслова Т.Д. ИП-21-3 
#### Инструментальные средства разработки программного обеспечения

### Описание:

* Покупатели могут купить товары со склада гвоздей. Для этого составляется товарная накладная, которая включает в себя: Номер накладной, её дату исполнения,
данные покупателя (Наименование, ИНН, адрес), список покупаемых товаров, их итоговый налог и итоговую сумму.

* Для этого была разработана База Данных системы накладных Склада Гвоздей:

```mermaid
  classDiagram
    Sale <|-- Product
    Sale <|-- Invoice
    Invoice <|-- Customer

    class Sale{
      +UniqueIdentifier IdSale
      +UniqueIdentifier ProductId
      +UniqueIdentifier InvoiceId
      +int SoldCount
      -
      -DateTimeOffset CreatedDate
      -DateTimeOffset UpdatedDate
      -DateTimeOffset DeletedDate 
    }
    class Invoice{
      +UniqueIdentifier IdInvoice
      +UniqueIdentifier CustomerId
      +DateTimeOffset ExecutionDate
      -
      -DateTimeOffset CreatedDate
      -DateTimeOffset UpdatedDate
      -DateTimeOffset DeletedDate 
    }
    class Customer{
      +UniqueIdentifier IdCustomer
      +nvarchar[255] Name
      +varchar[12] INN
      +nvarchar[1023] Address
      -
      -DateTimeOffset CreatedDate
      -DateTimeOffset UpdatedDate
      -DateTimeOffset DeletedDate 
    }
    class Product{
      +UniqueIdentifier IdProduct
      +nvarchar[255] Name
      +decimal Price
      -
      -DateTimeOffset CreatedDate
      -DateTimeOffset UpdatedDate
      -DateTimeOffset DeletedDate 
    }
```

* Готовая накладная должна выглядеть так: 
