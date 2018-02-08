using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WissenBakkal.Entitiy.Entities;

namespace WissenBakkal.BLL.Repositories
{
    public class ProductRepo : BaseRespository<Product, string> { }
    public class OrderRepo : BaseRespository<Order, int> { }
    public class OrderDetailRepo : BaseRespository<OrderDetail, int> { }
    public class SaleRepo : BaseRespository<Sale, int> { }
    public class SaleDetailRepo : BaseRespository<SaleDetail, int> { }
    public class SupplierRepo : BaseRespository<Supplier, int> { }
    public class CustomerRepo : BaseRespository<Customer, int> { }
    public class CustomerPaymentRepo : BaseRespository<Customer, int> { }
    public class CategoryRepo : BaseRespository<Category, int> { }

}
