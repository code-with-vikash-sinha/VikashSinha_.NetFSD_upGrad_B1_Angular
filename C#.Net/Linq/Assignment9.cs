class Order2
{
    public int Id;
    public string CustomerName;
    public DateTime OrderDate;
    public double TotalAmount;
}

var orders2 = new List<Order2>();

// 1
var last30 = orders2.Where(o => o.OrderDate >= DateTime.Now.AddDays(-30));

// 2
var monthly = orders2.GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
    .Select(g => new { g.Key, Total = g.Sum(x => x.TotalAmount) });

// 3
var top5 = orders2.GroupBy(o => o.CustomerName)
    .Select(g => new { Name = g.Key, Total = g.Sum(x => x.TotalAmount) })
    .OrderByDescending(x => x.Total)
    .Take(5);

// 4
var highestPerMonth = orders2.GroupBy(o => o.OrderDate.Month)
    .Select(g => g.OrderByDescending(x => x.TotalAmount).First());