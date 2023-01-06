using System.Data;
using System.Data.SqlClient;
namespace _6USProcedure
{
    internal class Program
    {
        public static readonly string connString =
           "Persist Security Info=False;User ID=sa;Password=yourStrong(!)Password;Initial Catalog=ADO_HW;Server=localhost";
        static void Main(string[] args)
        {
            //Create an UD-Stored Procedure called “The Signiture Menu” to get TOP3 expensive
            //Pizzas and execute the SP using your.NET application
            ////using dataadapter
            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(connString))
            //    {
            //        conn.Open();
            //        Console.WriteLine("DataTable Result(Stored Procedure) : ");
            //        SqlDataAdapter adapter = new SqlDataAdapter("SignitureMenu", conn);
            //        //Specify the Command type as Stored Procedure
            //        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            //        DataTable dataTable = new DataTable();
            //        adapter.Fill(dataTable);
            //        foreach (DataRow row in dataTable.Rows)
            //        {
            //            Console.WriteLine(row["Name"]);
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Something wrong with SqlDataAdapter: " + ex.Message);
            //    throw ex;
            //}

            //using datareader
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SignitureMenu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine(reader["Name"]);
                        }
                    }
                }
            }

        }
    }
}