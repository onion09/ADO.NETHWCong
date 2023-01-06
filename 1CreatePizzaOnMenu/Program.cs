using System.Data.SqlClient;
using System.Data;
namespace _1CreatePizzaOnMenu
{
    internal class Program
    {
        public static readonly string connString =
            "Persist Security Info=False;User ID=sa;Password=yourStrong(!)Password;Initial Catalog=ADO_HW;Server=localhost";

        static void Main(string[] args)
        {
            string query = "SELECT * FROM dbo.Pizza";
            
            //using SqlDataAdapter to insert row
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();


                //fetch data from database to adpter then fill into local dataTable
               
                SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
            
                //inserting rows to datatable
                DataRow newRow = dataTable.NewRow();
                newRow[1] = "deep plate2";
                newRow[2] = 11.11;
                dataTable.Rows.Add(newRow);

                //dataTable.AcceptChanges();


                //using CommandBuilder to create SqlCommand and apply on the adapter
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                //relect chbages to database
                adapter.Update(dataTable);
                Console.WriteLine("Changes update to the database via SqlDataAdapter");

                //Commit changes to dataset
                dataTable.AcceptChanges();
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row[1] + ", " + row[2]);
                }
                //foreach (DataRow row in dataTable.Rows)
                //{
                //    PizzaClass pizza = new PizzaClass()
                //    {
                //        Id = int.Parse(row["Id"].ToString()),
                //        Name = row["Name"].ToString(),
                //        Price = float.Parse(row[2].ToString())
                //    };
                //}
            }

            ////using DataReader to insert row
            //using(SqlConnection conn2 = new SqlConnection(connString))
            //{
            //    conn2.Open();
            //    string insert = "INSERT INTO dbo.Pizza VALUES(@value2,@value3)";
            //    using(SqlCommand command  = new SqlCommand(insert,conn2))
            //    {
            //        command.Parameters.AddWithValue("@value2", "Everything");
            //        command.Parameters.AddWithValue("@value3", 12.22);
            //        int rowAffected = command.ExecuteNonQuery();
            //        Console.WriteLine(rowAffected + " row(s) affected.");
            //    }
            //}

        }

    }
}
