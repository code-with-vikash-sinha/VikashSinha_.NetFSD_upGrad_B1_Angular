using System.Data;
using System.Data.SqlClient;

// INSERT via Stored Procedure
void InsertEmployee(string name, decimal salary, string dept)
{
    using SqlConnection con = new SqlConnection(connStr);

    SqlCommand cmd = new SqlCommand("InsertEmployee", con);
    cmd.CommandType = CommandType.StoredProcedure;

    cmd.Parameters.AddWithValue("@Name", name);
    cmd.Parameters.AddWithValue("@Salary", salary);
    cmd.Parameters.AddWithValue("@Department", dept);

    con.Open();
    cmd.ExecuteNonQuery();
}

// FETCH by Department
void GetByDept(string dept)
{
    using SqlConnection con = new SqlConnection(connStr);

    SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE Department=@d", con);
    cmd.Parameters.AddWithValue("@d", dept);

    con.Open();
    var dr = cmd.ExecuteReader();

    while (dr.Read())
        Console.WriteLine(dr["Name"]);
}

// UPDATE Salary (Stored Procedure)
void UpdateSalary(int id, decimal salary)
{
    using SqlConnection con = new SqlConnection(connStr);

    SqlCommand cmd = new SqlCommand("UpdateSalary", con);
    cmd.CommandType = CommandType.StoredProcedure;

    cmd.Parameters.AddWithValue("@EmpId", id);
    cmd.Parameters.AddWithValue("@Salary", salary);

    con.Open();
    cmd.ExecuteNonQuery();
}

// DELETE
void DeleteEmp(int id)
{
    using SqlConnection con = new SqlConnection(connStr);

    SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmpId=@id", con);
    cmd.Parameters.AddWithValue("@id", id);

    con.Open();
    cmd.ExecuteNonQuery();
}