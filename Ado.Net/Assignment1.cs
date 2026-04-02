using System;
using System.Data.SqlClient;

class StudentCRUD
{
    static string connStr = "Server=.;Database=YourDB;Trusted_Connection=True;";

    // 1. INSERT
    public static void AddStudent(string name, int age, string grade)
    {
        using (SqlConnection con = new SqlConnection(connStr))
        {
            string query = "INSERT INTO Students(Name,Age,Grade) VALUES(@n,@a,@g)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@a", age);
            cmd.Parameters.AddWithValue("@g", grade);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // 2. READ
    public static void GetStudents()
    {
        using (SqlConnection con = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr["Id"]} {dr["Name"]} {dr["Age"]} {dr["Grade"]}");
            }
        }
    }

    // 3. UPDATE
    public static void UpdateGrade(int id, string grade)
    {
        using (SqlConnection con = new SqlConnection(connStr))
        {
            string q = "UPDATE Students SET Grade=@g WHERE Id=@id";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@g", grade);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // 4. DELETE
    public static void DeleteStudent(int id)
    {
        using (SqlConnection con = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE Id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}