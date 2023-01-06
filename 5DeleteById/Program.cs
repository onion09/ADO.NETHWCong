using System.Data;
using System.Data.SqlClient;
namespace _5DeleteById
{
    internal class Program
    {
        public static readonly string connString =
           "Persist Security Info=False;User ID=sa;Password=yourStrong(!)Password;Initial Catalog=ADO_HW;Server=localhost";
        static void Main(string[] args)
        {
            //5. Delete a Pizza by its unique Id
            ////using DataReader
            //int id1 = 1;
            //string query1 = "DELETE FROM dbo.Pizza WHERE Id = @id";
            //using(SqlConnection conn = new SqlConnection(connString))
            //{
            //    conn.Open();
            //    SqlCommand cmd1 = new SqlCommand(query1, conn);
            //    cmd1.Parameters.AddWithValue("@id", id1);
            //    int rowsAffected = cmd1.ExecuteNonQuery();
            //    Console.WriteLine(rowsAffected);
            //}

            //using DataAdapter
            int id2 = 4;
            string query2 = "SELECT * FROM dbo.Pizza";
            using(SqlConnection conn2  = new SqlConnection(connString))
            {
                conn2.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query2, conn2);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach(DataRow row in dataTable.Rows)
                {
                    if (int.Parse(row[0].ToString()) == id2)
                    {
                        row.Delete();
                        Console.WriteLine("Row in " + row.RowState + " State");
                    }
                }
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dataTable);
                dataTable.AcceptChanges();
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row["Id"] + ", " + row["Name"]);
                }

            }
        }
    }
}