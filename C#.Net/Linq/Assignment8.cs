class Student2
{
    public int Id;
    public string Name;
    public string Class;
    public string Subject;
    public int Marks;
}

var students2 = new List<Student2>();

var grouped = students2
    .GroupBy(s => s.Class)
    .Select(c => new
    {
        Class = c.Key,
        Subjects = c.GroupBy(s => s.Subject)
                    .Select(sg => new
                    {
                        Subject = sg.Key,
                        AvgMarks = sg.Average(x => x.Marks)
                    })
    });