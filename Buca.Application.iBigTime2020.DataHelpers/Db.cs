using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Microsoft.Win32;

namespace Buca.Application.iBigTime2020.DataHelpers
{
    /// <summary>
    /// Manages all lower level ADO.NET data base access.
    /// </summary>
    /// <remarks>
    /// GoF Design Patterns: Singleton, Factory, Proxy.
    /// 
    /// This class is the 'swiss army knife' of ADO.NET data access. It handles all  
    /// database access details and shields its complexity from its clients.
    /// 
    /// The Factory Design pattern is used to create database specific instances
    /// of Connection objects, Command objects, etc.
    /// 
    /// This class is like a Singleton -- it is a static class (Shared in VB) and 
    /// therefore only one class-'instance' ever will exist.
    /// 
    /// This class is a Proxy in that it 'stands in' for the actual DbProviderFactory.
    /// </remarks>
    public static class Db
    {
        // Note: Static initializers are thread safe.
        // If this class had a static constructor then these static variables 
        // would need to be initialized there.
        private static readonly string DataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly DbProviderFactory Factory = DbProviderFactories.GetFactory(DataProvider);

        private static readonly string ConnectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        private static string _connectionString;
        //private static readonly Crypto Crypto = new Crypto(Crypto.SymmProvEnum.Rijndael);

        #region Fast data readers

        /// <summary>
        /// Reads the specified SQL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="isProcedure">if set to <c>true</c> [is procedure].</param>
        /// <param name="make">The make.</param>
        /// <param name="parms">The parms.</param>
        /// <returns></returns>
        /// 
        /// 

        public static string ConnectionStrings()
        {
            string ConnectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
            string ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            //string ConnectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = MAI3006; Integrated Security = True";


            return ConnectionString;
        }

        public static T Read<T>(string sql, bool isProcedure, Func<IDataReader, T> make, object[] parms = null)
        {
            using (var connection = Factory.CreateConnection())
            {
                Debug.Assert(connection != null, "connection != null");

                //thangnd comment
                //_connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                //                                                GetValueByRegistryKey("InstanceName"),
                //                                                GetValueByRegistryKey("DatabaseName"),
                //                                                GetValueByRegistryKey("UserName"),
                //                                                GetValueByRegistryKey("Password"));
                connection.ConnectionString = ConnectionStrings();

                using (var command = Factory.CreateCommand())
                {
                    Debug.Assert(command != null, "command != null");
                    command.Connection = connection;
                    command.CommandType = isProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    command.CommandText = sql;
                    command.SetParameters(parms);
                    command.CommandTimeout = 600;
                    // Extension method

                    connection.Open();

                    T t = default(T);
                    var reader = command.ExecuteReader();
                    if (reader.Read())

                        t = make(reader);

                    return t;
                }
            }
        }

        /// <summary>
        /// Reads the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="isProcedure">if set to <c>true</c> [is procedure].</param>
        /// <param name="make">The make.</param>
        /// <param name="parms">The parms.</param>
        /// <returns></returns>
        public static List<T> ReadList<T>(string sql, bool isProcedure, Func<IDataReader, T> make, object[] parms = null)
        {

            using (var connection = Factory.CreateConnection())
            {
                Debug.Assert(connection != null, "connection != null");

                //thangnd comment
                //_connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                //                                                GetValueByRegistryKey("InstanceName"),
                //                                                GetValueByRegistryKey("DatabaseName"),
                //                                                GetValueByRegistryKey("UserName"),
                //                                                GetValueByRegistryKey("Password"));
                connection.ConnectionString = ConnectionStrings();
                

                using (var command = Factory.CreateCommand())
                {
                    Debug.Assert(command != null, "command != null");
                    command.Connection = connection;
                    command.CommandType = isProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    command.CommandText = sql;
                    command.SetParameters(parms);
                    command.CommandTimeout = 600;
                    connection.Open();
                    var list = new List<T>();


                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        list.Add(make(reader));

                    return list;
                }
            }
        }

        public static DataTable ReadDataTable(string procedure, bool isProcedure, object[] parms = null)
        {
            using (var connection = Factory.CreateConnection())
            {
                Debug.Assert(connection != null, "connection != null");

                //thangnd comment
                //_connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                //                                                GetValueByRegistryKey("InstanceName"),
                //                                                GetValueByRegistryKey("DatabaseName"),
                //                                                GetValueByRegistryKey("UserName"),
                //                                                GetValueByRegistryKey("Password"));
                connection.ConnectionString = ConnectionStrings();

                using (var command = Factory.CreateCommand())
                {
                    Debug.Assert(command != null, "command != null");
                    command.Connection = connection;
                    command.CommandType = isProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    command.CommandText = procedure;
                    command.SetParameters(parms);

                    connection.Open();

                    DataTable dt = new DataTable();
                    dt.Load(command.ExecuteReader());
                    return dt;
                }
            }
        }

        public static DataSet ReadDataSet(string procedure, bool isProcedure, object[] parms = null)
        {
            using (var connection = Factory.CreateConnection())
            {
                Debug.Assert(connection != null, "connection != null");

                //thangnd comment
                //_connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                //                                                GetValueByRegistryKey("InstanceName"),
                //                                                GetValueByRegistryKey("DatabaseName"),
                //                                                GetValueByRegistryKey("UserName"),
                //                                                GetValueByRegistryKey("Password"));
                connection.ConnectionString = ConnectionStrings();

                using (var command = Factory.CreateCommand())
                {
                    Debug.Assert(command != null, "command != null");
                    command.Connection = connection;
                    command.CommandType = isProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    command.CommandText = procedure;
                    command.SetParameters(parms);

                    connection.Open();

                    DbDataAdapter adapter = Factory.CreateDataAdapter();
                    adapter.SelectCommand = command;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    return dataSet;
                }
            }
        }

        /// <summary>
        /// Gets a record count.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int GetCount(string sql, object[] parms = null)
        {
            return GetScalar(sql, parms).AsInt();
        }

        /// <summary>
        /// Gets any scalar value from the database.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static object GetScalar(string sql, object[] parms = null)
        {
            using (var connection = Factory.CreateConnection())
            {
                Debug.Assert(connection != null, "connection != null");

                //thangnd comment
                //_connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                //                                GetValueByRegistryKey("InstanceName"),
                //                                GetValueByRegistryKey("DatabaseName"),
                //                                GetValueByRegistryKey("UserName"),
                //                                GetValueByRegistryKey("Password"));
                connection.ConnectionString = ConnectionStrings();

                using (var command = Factory.CreateCommand())
                {
                    Debug.Assert(command != null, "command != null");
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Gets the sequences.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parms">The parms.</param>
        /// <returns></returns>
        public static int GetSequences(string sql, object[] parms = null)
        {
            using (var connection = Factory.CreateConnection())
            {
                Debug.Assert(connection != null, "connection != null");

                //thangnd comment
                //_connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                //                                 GetValueByRegistryKey("InstanceName"),
                //                                 GetValueByRegistryKey("DatabaseName"),
                //                                 GetValueByRegistryKey("UserName"),
                //                                 GetValueByRegistryKey("Password"));
                connection.ConnectionString = ConnectionStrings();

                using (var command = Factory.CreateCommand())
                {
                    Debug.Assert(command != null, "command != null");
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);

                    connection.Open();
                    return command.ExecuteScalar().AsInt();
                }
            }
        }

        #endregion

        #region Data update section
        /// <summary>
        /// Inserts the specified SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="isProcedure">if set to <c>true</c> [is procedure].</param>
        /// <param name="parms">The parms.</param>
        /// <returns></returns>
        public static string Insert(string sql, bool isProcedure, object[] parms = null)
        {
            using (var connection = Factory.CreateConnection())
            {
                Debug.Assert(connection != null, "connection != null");

                //thangnd comment
                //_connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                //                                 GetValueByRegistryKey("InstanceName"),
                //                                 GetValueByRegistryKey("DatabaseName"),
                //                                 GetValueByRegistryKey("UserName"),
                //                                 GetValueByRegistryKey("Password"));
                connection.ConnectionString = ConnectionStrings();

                using (var command = Factory.CreateCommand())
                {
                    Debug.Assert(command != null, "command != null");
                    command.Connection = connection;
                    command.SetParameters(parms);                     // Extension method  
                    command.CommandType = isProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    command.CommandText = sql;
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    return command.ExecuteScalar().AsString();
                }
            }
        }
        public static int InsertInt(string sql, bool isProcedure, object[] parms = null)
        {
            using (var connection = Factory.CreateConnection())
            {
                Debug.Assert(connection != null, "connection != null");
                //_connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                //                                 GetValueByRegistryKey("InstanceName"),
                //                                 GetValueByRegistryKey("DatabaseName"),
                //                                 GetValueByRegistryKey("UserName"),
                //                                 GetValueByRegistryKey("Password"));
                //connection.ConnectionString = _connectionString;
                connection.ConnectionString = ConnectionStrings();
                using (var command = Factory.CreateCommand())
                {
                    Debug.Assert(command != null, "command != null");
                    command.Connection = connection;
                    command.SetParameters(parms);                     // Extension method  
                    command.CommandType = isProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    command.CommandText = sql;
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    return command.ExecuteScalar().AsInt();
                }
            }
        }



        public static string ConvertDB(string sql, bool isProcedure, object[] parms = null)
        {
            using (var connection = Factory.CreateConnection())
            {
                Debug.Assert(connection != null, "connection != null");

                //thangnd comment
                _connectionString = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;",
                                                 GetValueByRegistryKey("InstanceName"),
                                                 GetValueByRegistryKey("DatabaseName")
                                               );
                connection.ConnectionString = _connectionString;

                using (var command = Factory.CreateCommand())
                {
                    Debug.Assert(command != null, "command != null");
                    command.Connection = connection;
                    command.SetParameters(parms);                     // Extension method  
                    command.CommandType = isProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    command.CommandText = sql;
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    return command.ExecuteScalar().AsString();
                }
            }
        }


        /// <summary>
        /// Updates the specified SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="isProcedure">if set to <c>true</c> [is procedure].</param>
        /// <param name="parms">The parms.</param>
        /// <returns></returns>
        public static string Update(string sql, bool isProcedure, object[] parms = null)
        {
            using (var connection = Factory.CreateConnection())
            {
                Debug.Assert(connection != null, "connection != null");
                //thangnd comment
                //_connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                //                                GetValueByRegistryKey("InstanceName"),
                //                                GetValueByRegistryKey("DatabaseName"),
                //                                GetValueByRegistryKey("UserName"),
                //                                GetValueByRegistryKey("Password"));
                connection.ConnectionString = ConnectionStrings();

                using (var command = Factory.CreateCommand())
                {
                    Debug.Assert(command != null, "command != null");
                    command.Connection = connection;
                    command.CommandType = isProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    command.CommandText = sql;
                    command.SetParameters(parms);

                    connection.Open();
                    return command.ExecuteScalar().AsString();
                }
            }
        }

        /// <summary>
        /// Deletes the specified SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="isProcedure">if set to <c>true</c> [is procedure].</param>
        /// <param name="parms">The parms.</param>
        /// <returns></returns>
        public static string Delete(string sql, bool isProcedure, object[] parms = null)
        {
            return Update(sql, isProcedure, parms);
        }

        #endregion

        #region Extension methods

        /// <summary>
        /// Extention method. Adds query parameters to command object.
        /// </summary>
        /// <param name="command">Command object.</param>
        /// <param name="parms">Array of name-value query parameters.</param>
        private static void SetParameters(this DbCommand command, object[] parms)
        {
            if (parms != null && parms.Length > 0)
            {
                // NOTE: Processes a name/value pair at each iteration
                for (int i = 0; i < parms.Length; i += 2)
                {
                    string name = parms[i].ToString();

                    // No empty strings to the database
                    if (parms[i + 1] is string && (string)parms[i + 1] == "")
                        parms[i + 1] = null;

                    // If null, set to DbNull
                    object value = parms[i + 1] ?? DBNull.Value;

                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = name;
                    dbParameter.Value = value;

                    command.Parameters.Add(dbParameter);
                }
            }
        }

        /// <summary>
        /// Gets the value by registry key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private static string GetValueByRegistryKey(string key)
        {
            var winLogonKey = Registry.CurrentUser.OpenSubKey(@"BuCAJSC\iBigTime2020");
            if (winLogonKey != null)
                return winLogonKey.GetValue(key) == null ? null : (string)winLogonKey.GetValue(key);
            return null;
        }

        /// <summary>
        /// Removes the duplicate words.
        /// </summary>
        /// <param name="v">The v.</param>
        /// <returns></returns>
        public static string RemoveDuplicateWords(string v)
        {
            // 1. Keep track of words found in this Dictionary.
            var d = new Dictionary<string, bool>();

            // 2. Build up string into this StringBuilder.
            var b = new StringBuilder();

            // 3. Split the input and handle spaces and punctuation.
            string[] a = v.Split(new[] { ' ', ',', ';', '.' },
                StringSplitOptions.RemoveEmptyEntries);

            // 4. Loop over each word
            foreach (string current in a)
            {
                // 5. Lowercase each word
                string lower = current.ToLower();

                // 6. If we haven't already encountered the word, append it to the result.
                if (!d.ContainsKey(lower))
                {
                    b.Append(current).Append(", ");
                    d.Add(lower, true);
                }
            }
            // 7. Return the duplicate words removed
            return b.ToString().Trim().Remove(b.ToString().Trim().Length, 1);
        }
        #endregion
    }
}
