var nums = new List<int> { 1,2,3,2,4,5,3,6 };

// 1
var unique = nums.Distinct();

// 2
var duplicates = nums.GroupBy(n => n)
                     .Where(g => g.Count() > 1)
                     .Select(g => g.Key);

// 3
var countOcc = nums.GroupBy(n => n)
                   .Select(g => new { Number = g.Key, Count = g.Count() });