using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class DBManager
    {
        SqlDataReader rdr = null;
        SqlConnection conn = null;
          public DBManager()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"data source=(localdb)\mssqllocaldb; initial catalog=test; integrated security=true";
        }

        public void addtotatble(string title, int amount)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = $"insert into products values('{title}',{amount})";
            command.ExecuteNonQuery();
        }
       
     public void SelectAll()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "select * from products";
            rdr = command.ExecuteReader();
            int line = 0;
            while (rdr.Read())
            {
                if(line==0)
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        Console.Write(rdr.GetName(i) + '\t');
                    }
                }
                
                Console.WriteLine();
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    Console.Write(rdr[i].ToString()+'\t');
                }
                line++;
            }
        }
        public void SelectFromManyTables()
        {
           
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            //command.CommandText = "select * from products; select * from customers;";
            command.CommandText = "select * from products";
            rdr = command.ExecuteReader();
            int line = 0;
            //do {
                while (rdr.Read())
                {
                    if (line == 0)
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            Console.Write(rdr.GetName(i) + '\t');
                        }
                    }
                    
                    Console.WriteLine();
                    Console.WriteLine( rdr["Id"]+"\t"+rdr["title"]+"\t"+rdr["amount"]);
                    //for (int i = 0; i < rdr.FieldCount; i++)
                    //{
                    //    Console.Write(rdr[i].ToString() + '\t');
                    //}
                    line++;
                }
            //}
            //while (rdr.NextResult());
           
        }
        public void SelectAvgAmount()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "select avg(amount) from products";
            var avg = command.ExecuteScalar();
            Console.WriteLine("avg = {0:f2}", Convert.ToDouble(avg));
        }
        public void connect()
        {
            conn.Open();
            Console.WriteLine("Ok");

        }
        public void close()
        {
            if(conn!=null)
            conn.Close();
        }
    }
}
