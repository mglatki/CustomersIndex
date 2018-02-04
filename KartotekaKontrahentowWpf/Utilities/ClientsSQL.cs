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
            string txtSQLQuery = "INSERT INTO clients (name, adr_country, adr_city, adr_street, adr_str_numb, cont_phone, cont_email, buss_client) VALUES ('" +
                name + "','" + adr_country + "','" + adr_city + "','" + adr_street + "','" + adr_str_numb + "','" + buss_client + "')";
            try
            {
                await ExecuteQuery(txtSQLQuery);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static async Task UpdateClientAsync(int id, string name, string adr_country, string adr_city, string adr_street, string adr_str_numb, string cont_phone, string cont_email, byte buss_client)
        {
            string txtSQLQuery = String.Format("UPDATE clients SET name = {0}, adr_country = {1}, adr_city = {2}, adr_street = {3}, adr_str_numb = {4}, cont_phone = {5}, cont_email = {6}, buss_client = {7} WHERE client_id = {8}",
                name, adr_country, adr_city, adr_street, adr_str_numb, cont_phone, cont_email, buss_client, id);
            ExecuteQuery(txtSQLQuery);
        }

        public static async Task DeleteClientAsync(int clientId)
        {
            string txtSQLQuery = "DELETE FROM clients WHERE client_id = '" + clientId.ToString() + "'";
            ExecuteQuery(txtSQLQuery);
        }
    }
}
