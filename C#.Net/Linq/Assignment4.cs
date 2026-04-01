class Employee
{
    public int Id;
    public string Name;
    public string Department;
    public double Salary;
}

var employees = new List<Employee>();

// 1
var itEmp = employees.Where(e => e.Department == "IT");

// 2
var highest = employees.OrderByDescending(e => e.Salary).FirstOrDefault();

// 3
var avgSalary = employees.Average(e => e.Salary);

// 4
var groupDept = employees.GroupBy(e => e.Department);

// 5
var countDept = employees.GroupBy(e => e.Department)
                         .Select(g => new { Dept = g.Key, Count = g.Count() });