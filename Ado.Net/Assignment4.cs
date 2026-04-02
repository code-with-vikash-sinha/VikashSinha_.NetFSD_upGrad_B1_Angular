using System.Data.SqlClient;

using SqlConnection con = new SqlConnection(connStr);
con.Open();

SqlTransaction trans = con.BeginTransaction();

try
{
    SqlCommand cmd1 = new SqlCommand(
        "INSERT INTO Orders(CustomerName,TotalAmount) VALUES('Vikash',1000); SELECT SCOPE_IDENTITY();",
        con, trans);

    int orderId = Convert.ToInt32(cmd1.ExecuteScalar());

    SqlCommand cmd2 = new SqlCommand(
        "INSERT INTO OrderItems(OrderId,ProductName,Quantity) VALUES(@id,'Pen',2)",
        con, trans);

    cmd2.Parameters.AddWithValue("@id", orderId);
    cmd2.ExecuteNonQuery();

    trans.Commit();
}
catch
{
    trans.Rollback();
}