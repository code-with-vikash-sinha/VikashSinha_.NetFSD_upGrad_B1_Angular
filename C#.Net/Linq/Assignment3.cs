var names = new List<string> { "Ravi", "Kiran", "Amit", "Raj", "Anil" };

// 1
var startA = names.Where(n => n.StartsWith("A"));

// 2
var sortedNames = names.OrderBy(n => n);

// 3
var upper = names.Select(n => n.ToUpper());

// 4
var length4 = names.Where(n => n.Length > 4);