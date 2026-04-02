// ADD BOOK
void AddBook(string title, string author, decimal price)
{
    using SqlConnection con = new SqlConnection(connStr);
    SqlCommand cmd = new SqlCommand(
        "INSERT INTO Books VALUES(@t,@a,@p)", con);

    cmd.Parameters.AddWithValue("@t", title);
    cmd.Parameters.AddWithValue("@a", author);
    cmd.Parameters.AddWithValue("@p", price);

    con.Open();
    cmd.ExecuteNonQuery();
}

// VIEW
void ViewBooks()
{
    using SqlConnection con = new SqlConnection(connStr);
    SqlCommand cmd = new SqlCommand("SELECT * FROM Books", con);

    con.Open();
    var dr = cmd.ExecuteReader();

    while (dr.Read())
        Console.WriteLine(dr["Title"]);
}

// UPDATE
void UpdateBook(int id, decimal price)
{
    using SqlConnection con = new SqlConnection(connStr);
    SqlCommand cmd = new SqlCommand(
        "UPDATE Books SET Price=@p WHERE BookId=@id", con);

    cmd.Parameters.AddWithValue("@p", price);
    cmd.Parameters.AddWithValue("@id", id);

    con.Open();
    cmd.ExecuteNonQuery();
}

// DELETE
void DeleteBook(int id)
{
    using SqlConnection con = new SqlConnection(connStr);
    SqlCommand cmd = new SqlCommand(
        "DELETE FROM Books WHERE BookId=@id", con);

    cmd.Parameters.AddWithValue("@id", id);

    con.Open();
    cmd.ExecuteNonQuery();
}

// SEARCH
void SearchBook(string name)
{
    using SqlConnection con = new SqlConnection(connStr);
    SqlCommand cmd = new SqlCommand(
        "SELECT * FROM Books WHERE Title LIKE @n", con);

    cmd.Parameters.AddWithValue("@n", "%" + name + "%");

    con.Open();
    var dr = cmd.ExecuteReader();

    while (dr.Read())
        Console.WriteLine(dr["Title"]);
}