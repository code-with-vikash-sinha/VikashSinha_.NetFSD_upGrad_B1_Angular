class Product
{
    public int Id;
    public string Name;
    public string Category;
    public double Price;
    public int Stock;
}

var products = new List<Product>();

// 1
var lowStock = products.Where(p => p.Stock < 10);

// 2
var top3 = products.OrderByDescending(p => p.Price).Take(3);

// 3
var groupCat = products.GroupBy(p => p.Category);

// 4
var stockPerCat = products.GroupBy(p => p.Category)
    .Select(g => new { Category = g.Key, TotalStock = g.Sum(x => x.Stock) });

// 5
var outOfStock = products.Any(p => p.Stock == 0);