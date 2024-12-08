# Web API системы накладных Склада Гвоздей
### Маслова Т.Д. ИП-21-3 
#### Инструментальные средства разработки программного обеспечения

### Описание:

Покупатели могут заказать товары со склада гвоздей. Для этого составляется товарная накладная, которая включает в себя: Номер накладной, её дату исполнения,
данные покупателя (Наименование, ИНН, адрес), список покупаемых товаров, их итоговый налог и итоговую сумму.

### Шаблон готовой накладной: 

<img src="InvoicePhoto.png" alt="Фото накладной" width="500" align="center"/>

### Схема БД системы накладных Склада Гвоздей:
  
```mermaid
  classDiagram
    Sale <|-- Product
    Sale <|-- Invoice
    Invoice <|-- Customer

    class Sale{
      +UniqueIdentifier Id
      +UniqueIdentifier ProductId
      +UniqueIdentifier InvoiceId
      +int SoldCount
      -
      -DateTimeOffset CreatedDate
      -DateTimeOffset UpdatedDate
      -DateTimeOffset DeletedDate 
    }
    class Invoice{
      +UniqueIdentifier Id
      +UniqueIdentifier CustomerId
      +DateTimeOffset ExecutionDate
      -
      -DateTimeOffset CreatedDate
      -DateTimeOffset UpdatedDate
      -DateTimeOffset DeletedDate 
    }
    class Customer{
      +UniqueIdentifier Id
      +nvarchar[255] Name
      +varchar[12] INN
      +nvarchar[1023] Address
      -
      -DateTimeOffset CreatedDate
      -DateTimeOffset UpdatedDate
      -DateTimeOffset DeletedDate 
    }
    class Product{
      +UniqueIdentifier Id
      +nvarchar[255] Name
      +decimal Price
      -
      -DateTimeOffset CreatedDate
      -DateTimeOffset UpdatedDate
      -DateTimeOffset DeletedDate 
    }
```

### SQL запросы добавления данных в БД:

```sql
TODO;
```
