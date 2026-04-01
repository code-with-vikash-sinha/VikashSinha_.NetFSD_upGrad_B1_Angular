class Customer { public int Id; public string Name; }
class Order { public int Id; public int CustomerId; public double Amount; }

var customers = new List<Customer>();
var orders = new List<Order>();

// 1
var join = customers.Join(orders,
    c => c.Id,
    o => o.CustomerId,
    (c, o) => new { c.Name, o.Amount });

// 2
var totalPerCustomer = orders.GroupBy(o => o.CustomerId)
    .Select(g => new { CustomerId = g.Key, Total = g.Sum(x => x.Amount) });

// 3
var bigCustomers = totalPerCustomer.Where(c => c.Total > 5000);

// 4
var noOrders = customers.Where(c => !orders.Any(o => o.CustomerId == c.Id));