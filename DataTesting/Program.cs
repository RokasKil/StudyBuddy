using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertData();
            //SelectWithSelectCommand("Jane","Doe");
            Update();
            //SelectWithSelectCommand("Jack", "Johnson");


            SelectWithSelectCommand2();
            Console.ReadLine();

        }
        public static void InsertData()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\mssqllocaldb; Integrated Security = True";
            cn.Open();

            SqlCommand insert = new SqlCommand();
            insert.Connection = cn;
            insert.CommandType = CommandType.Text;
            insert.CommandText = "INSERT INTO Person (FirstName, LastName) VALUES (@FN,@LN)";

            insert.Parameters.Add(new SqlParameter("@FN", SqlDbType.NVarChar, 50, "FirstName"));
            insert.Parameters.Add(new SqlParameter("@LN", SqlDbType.NVarChar, 50, "LastName"));

            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, FirstName, LastName FROM Person", cn);
            da.InsertCommand = insert;

            DataSet ds = new DataSet();
            da.Fill(ds, "Person");

            DataRow newRow = ds.Tables[0].NewRow();
            newRow["FirstName"] = "Jane";
            newRow["LastName"] = "Doe";
            ds.Tables[0].Rows.Add(newRow);

            da.Update(ds.Tables[0]);


            cn.Close();
            da.Dispose();
        }

        static public void SelectWithSelectCommand(String firstName, String lastName)
        {
            string myCon = @"Data Source = (localdb)\mssqllocaldb; Integrated Security = True";

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = myCon;
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName FROM Person" +
                " WHERE FirstName = @FN and LastName = @LN", cn);

            command.Parameters.AddWithValue("@FN", firstName);
            command.Parameters.AddWithValue("@LN", lastName);

            da.SelectCommand = command;

            DataSet ds = new DataSet();
            da.Fill(ds, "Person");

            cn.Close();
            da.Dispose();

            Console.WriteLine(ds.Tables[0].Rows[0]["LastName"]);
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                Console.Write(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                Console.Write(" ");
                Console.WriteLine(ds.Tables[0].Rows[i].ItemArray[2].ToString());
            }
        }

        static public void SelectWithSelectCommand2()
        {
            string myCon = @"Data Source = (localdb)\mssqllocaldb; Integrated Security = True";

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = myCon;
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName FROM Person", cn);

            da.SelectCommand = command;

            DataSet ds = new DataSet();
            da.Fill(ds, "Person");

            cn.Close();
            da.Dispose();

            Console.WriteLine(ds.Tables[0].Rows[0]["LastName"]);
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                Console.Write(ds.Tables[0].Rows[i].ItemArray[1].ToString());
                Console.Write(" ");
                Console.WriteLine(ds.Tables[0].Rows[i].ItemArray[2].ToString());
            }
        }

        static public void Update()
        {
            string myCon = @"Data Source = (localdb)\mssqllocaldb; Integrated Security = True";

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = myCon;
            cn.Open();

            SqlCommand update = new SqlCommand();
            update.Connection = cn;
            update.CommandType = CommandType.Text;
            update.CommandText = "UPDATE Person SET FirstName = @FN, LastName = @LN WHERE Id = @Id";

            update.Parameters.Add(new SqlParameter("@FN", SqlDbType.NVarChar, 50, "FirstName"));
            update.Parameters.Add(new SqlParameter("@LN", SqlDbType.NVarChar, 50, "LastName"));
            update.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 50, "Id"));

            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, FirstName, LastName FROM Person", cn);
            da.UpdateCommand = update;

            DataSet ds = new DataSet();
            da.Fill(ds, "Person");

            ds.Tables[0].Rows[5]["FirstName"] = "Jack";
            ds.Tables[0].Rows[5]["LastName"] = "Johnson";

            da.Update(ds.Tables[0]);
            cn.Close();
            da.Dispose();
        }
        /*
        private DataTable CopyDataTable(DataTable table)
        {
            // Create an object variable for the copy.
            DataTable copyDataTable;
            copyDataTable = table.Copy();

            return copyDataTable;
            // Insert code to work with the copy.
        }
        */
    }
}
