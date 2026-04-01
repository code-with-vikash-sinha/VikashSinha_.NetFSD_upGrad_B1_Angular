class Student
{
    public int Id;
    public string Name;
    public int Age;
    public int Marks;
}

var students = new List<Student>
{
    new Student{Id=1, Name="A", Age=20, Marks=80},
    new Student{Id=2, Name="B", Age=17, Marks=70},
    new Student{Id=3, Name="C", Age=22, Marks=90}
};

// 1
var highMarks = students.Where(s => s.Marks > 75);

// 2
var ageRange = students.Where(s => s.Age >= 18 && s.Age <= 25);

// 3
var sorted = students.OrderByDescending(s => s.Marks);

// 4
var nameMarks = students.Select(s => new { s.Name, s.Marks });