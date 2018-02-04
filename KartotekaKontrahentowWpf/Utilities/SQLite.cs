using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersIndex.Utilities
{
    public class SQLite
    {
        protected static SQLiteConnection sql_con;
        protected static SQLiteCommand sql_com;
        protected static string _dataBaseName;

        public SQLite()
        {

        }

        protected static void CreateDatabase(string dataBaseName)
        {
            _dataBaseName = dataBaseName;
            SQLiteConnection.CreateFile(dataBaseName);
        }

        protected static void SetConnection()
        {
            sql_con = new SQLiteConnection(String.Format("Data Source={0};Version=3;New=False;Compress=True;", _dataBaseName));
        }

        protected static async Task ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_com = sql_con.CreateCommand();
            sql_com.CommandText = txtQuery;
            sql_com.ExecuteNonQuery();
            sql_con.Close();
        }
    }
}
