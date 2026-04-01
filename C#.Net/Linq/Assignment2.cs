var numbers = new List<int> { 5, 10, 15, 20, 25, 30 };

// 1
var even = numbers.Where(n => n % 2 == 0);

// 2
var greater15 = numbers.Where(n => n > 15);

// 3
var squares = numbers.Select(n => n * n);

// 4
var countDiv5 = numbers.Count(n => n % 5 == 0);