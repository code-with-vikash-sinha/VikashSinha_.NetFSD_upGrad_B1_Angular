var sortedEmp = employees
    .OrderBy(e => e.Department)
    .ThenByDescending(e => e.Salary);