using System.Data;
using System.Data.SqlClient;

namespace _2ReadAllPizza
{
    internal class Program
    {
        public static readonly string connString =
            "Persist Security Info=False;User ID=sa;Password=yourStrong(!)Password;Initial Catalog=ADO_HW;Server=localhost";
        static void Main(string[] args)
        {

            //using DataAdpater to read all pizza
            using (SqlConnection conn1 = new SqlConnection(connString))
            {
                Console.WriteLine("Using DataAdapter");

                string query = "SELECT * FROM dbo.Pizza";
                conn1.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn1);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                DataTable dataTable1 = dataSet.Tables[0]; 

               

                foreach(DataRow row in dataTable1.Rows)
                {
                    Console.WriteLine(row[1] + "  " + row[2]);
                }
                Console.WriteLine("\n");
            }

            //using DataReader to read all pizza
            using(SqlConnection conn2 = new SqlConnection(connString))
            {
                conn2.Open();
                string query = "SELECT * FROM dbo.Pizza";

                SqlCommand command = new SqlCommand(query, conn2);
                
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Using DataReader");
                    while (reader.Read())
                       Console.WriteLine(reader[1]+ " " + reader[2]);
                }

                
            }
        }
    }
}