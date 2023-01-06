using System.Data;
using System.Data.SqlClient;

namespace DeleteViaId
{
    internal class Program
    {
        public static readonly string connString =
            "Persist Security Info=False;User ID=sa;Password=yourStrong(!)Password;Initial Catalog=ADO_HW;Server=localhost";
        static void Main(string[] args)
        {
            using(SqlConnection connection = new SqlConnection(connString)
            {

            }
        }
    }
}