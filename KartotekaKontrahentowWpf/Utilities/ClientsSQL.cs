using CustomersIndex.Interfaces;
using CustomersIndex.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomersIndex.Utilities
{
    public sealed class ClientsSQL : SQLite
    {
        private static readonly object padLock = new object(); // obiekt &quot;kłódeczki&quot;

        private static ClientsSQL instance;

        public static ClientsSQL Instance
        {
            get
            {
                lock (padLock) // instrukcja blokująca dostęp więcej niż jednemu wątkowi
                {
                    if (instance == null) // kiedy instancja nie istnieje...
                    {
                        instance = new ClientsSQL(); // utwórz ją wykorzystując prywatny konstruktor
                    }
                    return instance; // jeśli instancja istnieje - zwróć ją
                }
            }
        }

        private ClientsSQL() { }
        
        private static void CreateClientsTable()
        {
            string commandText = @"
            CREATE TABLE clients(
            client_id INTEGER PRIMARY KEY,
            name TEXT NOT NULL,
            adr_country TEXT NOT NULL,
            adr_city TEXT NOT NULL,
            adr_street TEXT NOT NULL,
            adr_str_numb TEXT,
            cont_phone TEXT NOT NULL,
            cont_email TEXT NOT NULL,
            buss_client INTEGER NOT NULL)";
            ExecuteQuery(commandText);
        }

        public static async Task<ObservableCollection<IClient>> GetClientsAsync()
        {
            _dataBaseName = "ClientsDatabase.db";

            if (!File.Exists(_dataBaseName))
            {
                CreateDatabase(_dataBaseName);
                CreateClientsTable();
            }

            SetConnection();

            sql_con.Open();
            sql_com = sql_con.CreateCommand();
            string CommandText = "select * from clients";

            sql_com = new SQLiteCommand(CommandText, sql_con);
            SQLiteDataReader reader = sql_com.ExecuteReader();
            ObservableCollection<IClient> clientsList = new ObservableCollection<IClient>();

            while (reader.Read())
            {
                if (Convert.ToBoolean(reader["buss_client"]))
                {
                    clientsList.Add(new BusinessClient(Convert.ToInt32(reader["client_id"]), reader["name"].ToString(), reader["adr_country"].ToString(), reader["adr_city"].ToString(), reader["adr_street"].ToString(), reader["adr_str_numb"].ToString(), reader["cont_phone"].ToString(), reader["cont_email"].ToString()));
                }
                else
                {
                    clientsList.Add(new IndividualClient(Convert.ToInt32(reader["client_id"]), reader["name"].ToString(), reader["adr_country"].ToString(), reader["adr_city"].ToString(), reader["adr_street"].ToString(), reader["adr_str_numb"].ToString(), reader["cont_phone"].ToString(), reader["cont_email"].ToString()));
                }
            }
            

            sql_con.Close();
            return clientsList;
        }

        public static async Task AddClientAsync(string name, string adr_country, string adr_city, string adr_street, string adr_str_numb, string cont_phone, string cont_email, byte buss_client)
        {
            sql_com = new SQLiteCommand(@"INSERT INTO clients (name, adr_country, adr_city, adr_street, adr_str_numb, cont_phone, cont_email, buss_client) 
            VALUES (@name, @adr_country, @adr_city, @adr_street, @adr_str_numb, @cont_phone, @cont_email, @buss_client)");

            sql_com.Parameters.Add("@name", System.Data.DbType.String);
            sql_com.Parameters.Add("@adr_country", System.Data.DbType.String);
            sql_com.Parameters.Add("@adr_city", System.Data.DbType.String);
            sql_com.Parameters.Add("@adr_street", System.Data.DbType.String);
            sql_com.Parameters.Add("@adr_str_numb", System.Data.DbType.String);
            sql_com.Parameters.Add("@cont_phone", System.Data.DbType.String);
            sql_com.Parameters.Add("@cont_email", System.Data.DbType.String);
            sql_com.Parameters.Add("@buss_client", System.Data.DbType.Int16);

            sql_com.Parameters["@name"].Value = name;
            sql_com.Parameters["@adr_country"].Value = adr_country;
            sql_com.Parameters["@adr_city"].Value = adr_city;
            sql_com.Parameters["@adr_street"].Value = adr_street;
            sql_com.Parameters["@adr_str_numb"].Value = adr_str_numb;
            sql_com.Parameters["@cont_phone"].Value = cont_phone;
            sql_com.Parameters["@cont_email"].Value = cont_email;
            sql_com.Parameters["@buss_client"].Value = buss_client;

            try
            {
                SetConnection();
                sql_com.Connection = sql_con;
                sql_com.Connection.Open();
                await sql_com.ExecuteNonQueryAsync();
                sql_com.Connection.Close();

            }
            catch(SQLiteException sql_e)
            {
                string errorMessage = "Message: " + sql_e.Message + "\n" +
                        "Error Code: " + sql_e.ErrorCode + "\n" +
                        "Source: " + sql_e.Source + "\n" +
                        "Data: " + sql_e.Data + "\n";

                MessageBox.Show(errorMessage, "SQLite exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {

                string errorMessage = "Message: " + e.Message + "\n" +
                        "Source: " + e.Source + "\n" +
                        "Data: " + e.Data + "\n";

                MessageBox.Show(errorMessage, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static async Task UpdateClientAsync(int id, string name, string adr_country, string adr_city, string adr_street, string adr_str_numb, string cont_phone, string cont_email, byte buss_client)
        {
            sql_com = new SQLiteCommand(@"UPDATE clients SET name = @name, adr_country = @adr_country, adr_city = @adr_city, adr_street = @adr_street, 
adr_str_numb = @adr_str_numb, cont_phone = @cont_phone, cont_email = @cont_email, buss_client = @buss_client WHERE client_id =  @client_id;");

            sql_com.Parameters.Add("@name", System.Data.DbType.String);
            sql_com.Parameters.Add("@adr_country", System.Data.DbType.String);
            sql_com.Parameters.Add("@adr_city", System.Data.DbType.String);
            sql_com.Parameters.Add("@adr_street", System.Data.DbType.String);
            sql_com.Parameters.Add("@adr_str_numb", System.Data.DbType.String);
            sql_com.Parameters.Add("@cont_phone", System.Data.DbType.String);
            sql_com.Parameters.Add("@cont_email", System.Data.DbType.String);
            sql_com.Parameters.Add("@buss_client", System.Data.DbType.Int16);
            sql_com.Parameters.Add("@client_id", System.Data.DbType.Int64);

            sql_com.Parameters["@name"].Value = name;
            sql_com.Parameters["@adr_country"].Value = adr_country;
            sql_com.Parameters["@adr_city"].Value = adr_city;
            sql_com.Parameters["@adr_street"].Value = adr_street;
            sql_com.Parameters["@adr_str_numb"].Value = adr_str_numb;
            sql_com.Parameters["@cont_phone"].Value = cont_phone;
            sql_com.Parameters["@cont_email"].Value = cont_email;
            sql_com.Parameters["@buss_client"].Value = buss_client;
            sql_com.Parameters["@client_id"].Value = id;

            try
            {
                SetConnection();
                sql_com.Connection = sql_con;
                sql_com.Connection.Open();
                await sql_com.ExecuteNonQueryAsync();
                sql_com.Connection.Close();
            }
            catch (SQLiteException sql_e)
            {
                string errorMessage = "Message: " + sql_e.Message + "\n" +
                        "Error Code: " + sql_e.ErrorCode + "\n" +
                        "Source: " + sql_e.Source + "\n" +
                        "Data: " + sql_e.Data + "\n";

                MessageBox.Show(errorMessage, "SQLite exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {

                string errorMessage = "Message: " + e.Message + "\n" +
                        "Source: " + e.Source + "\n" +
                        "Data: " + e.Data + "\n";

                MessageBox.Show(errorMessage, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static async Task DeleteClientAsync(int clientId)
        {
            sql_com = new SQLiteCommand(@"DELETE FROM clients WHERE client_id = @client_id");

            sql_com.Parameters.Add("@client_id", System.Data.DbType.Int64);

            sql_com.Parameters["@client_id"].Value = clientId;
            
            try
            {
                sql_com.Connection = sql_con;
                sql_com.Connection.Open();
                await sql_com.ExecuteNonQueryAsync();
                sql_com.Connection.Close();
            }
            catch(SQLiteException sql_e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
