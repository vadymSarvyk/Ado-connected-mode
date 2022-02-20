using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            DBManager dBManager = new DBManager();
            dBManager.connect();
            // dBManager.SelectAll();
            //dBManager.SelectFromManyTables();
            dBManager.SelectAvgAmount();
            dBManager.close();

        }
    }
}
