using System.Data;
using System.Data.SqlClient;

SqlConnection con = new SqlConnection(connStr);
SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);

DataSet ds = new DataSet();
da.Fill(ds, "Products");

DataTable dt = ds.Tables["Products"];

// ADD
DataRow newRow = dt.NewRow();
newRow["ProductName"] = "Laptop";
newRow["Price"] = 50000;
newRow["Stock"] = 10;
dt.Rows.Add(newRow);

// UPDATE
dt.Rows[0]["Price"] = 60000;

// DELETE
dt.Rows[1].Delete();

// PUSH CHANGES
SqlCommandBuilder cb = new SqlCommandBuilder(da);
da.Update(ds, "Products");