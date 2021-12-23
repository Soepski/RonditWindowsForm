using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Fontys_Hub
{
    public class Database
    {
        public SqlConnection Con;
        public Database()
        {
            Connect();
            Disconnect();
        }

        public void Connect()
        {
            Con = new SqlConnection("Server=mssql.fhict.local;Database=dbi413096;User Id=dbi413096;Password=boyke7r7_;");
            try
            {
                Con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Je VPN of de database staat niet aan");
            }
            
        }

        public void Disconnect()
        {
            Con.Close();
        }

        //Returns DataTable from query result
        public DataTable ExecuteStringQuery(String Query)
        {
            DataTable Result = new DataTable();

            Connect();

            if (Verify() == true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(Query, Con);
                adapter.Fill(Result);
            }
            //MySqlCommand Command = new MySqlCommand(Query, Con);

            Disconnect();

            return Result;
        }

        //Returns the first column of the first row in the result set returned by the query. Additional columns or rows are ignored.
        public string ExecuteScalar(String Query)
        {
            this.Connect();

            SqlCommand Command = new SqlCommand(Query, Con);

            string result = Command.ExecuteScalar().ToString();

            this.Disconnect();

            return result;
        }

        //Executes a Transact-SQL statement against the connection and returns the number of rows affected.
        public int ExecuteNonQuery(String Query)
        {
            this.Connect();

            SqlCommand Command = new SqlCommand(Query, Con);

            int result = Command.ExecuteNonQuery();

            this.Disconnect();

            return result;
        }

        public bool Verify()
        {
            Console.WriteLine(this.Con.State);
            if (this.Con.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
