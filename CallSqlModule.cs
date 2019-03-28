using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace KOTL
{
    #region Database Query (Must run on mysql server for Backup Functionalities) ~Deys
    /*
     * Run on SQL for long blob(Binary Image):
     * - SET GLOBAL max_allowed_packet = 16777216
     * - show variables like 'max_allowed_packet';
     * - set global max_allowed_packet=1024 * 1024 * 512;
     */
    #endregion
    class CallSqlModule
    {
        #region Sql Variables and Connections
        String sqlconnection = "datasource = localhost;port = 3306;Initial Catalog='SMCSM';username = root;password = 1234;";
        MySqlConnection myconn;
        MySqlDataAdapter sda;
        DataSet ds;
        MySqlCommandBuilder sb;
        MySqlCommand SelectCommand;
        MySqlDataReader myreader;
        DataTable table;
        #endregion

        public DataSet fillTable(string sql)
        {
            try
            {
                ds = new DataSet();
                myconn = new MySqlConnection(sqlconnection);
                sda = new MySqlDataAdapter(sql, myconn);
                sda.Fill(ds);
                sb = new MySqlCommandBuilder(sda);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Something's not right", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
            return ds;
        }

        public void onStartQuery()
        {
            saveInto("set global max_allowed_packet=1024 * 1024 * 512;");
            saveInto("set global max_allowed_packet=1024 * 1024 * 512;");
        }
        public string countSQL(string sql, string header)
        {
            string result = "";
            myconn = new MySqlConnection(sqlconnection);
            SelectCommand = new MySqlCommand(sql, myconn);

            myconn.Open();
            myreader = SelectCommand.ExecuteReader();
            while (myreader.Read())
            {
                result = myreader.GetString(header);
            }
            myconn.Close();
            return result;
        }
        public void runDatabaseScript()
        {
            string script = File.ReadAllText(@"D:\OSCA_DatabaseBackup.sql");

            // split script on GO command
            IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                     RegexOptions.Multiline | RegexOptions.IgnoreCase);
            myconn = new MySqlConnection(sqlconnection);
            myconn.Open();
            foreach (string commandString in commandStrings)
            {
                if (commandString.Trim() != "")
                {
                    using (var command = new MySqlCommand(commandString, myconn))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Database Import Successfully!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            myconn.Close();
        }
        public MySqlCommand sqlCommand(string sql)
        {
            myconn = new MySqlConnection(sqlconnection);
            SelectCommand = new MySqlCommand(sql, myconn);
            myconn.Open();
            return SelectCommand;
        }
        public void disposeTableDtTable() 
        {
            table.Dispose();
        }
        public Tuple<DataTable, MySqlCommand> tblCommand(string sql)
        {
            myconn = new MySqlConnection(sqlconnection);
            SelectCommand = new MySqlCommand(sql, myconn);
            sda = new MySqlDataAdapter(SelectCommand);
            table = new DataTable();
            sda.Fill(table);
            myconn.Open();
            return Tuple.Create(table, SelectCommand);
        }
        public DataTable binaryingImage(string sql)
        {
            myconn = new MySqlConnection(sqlconnection);
            SelectCommand = new MySqlCommand(sql, myconn);
            sda = new MySqlDataAdapter(SelectCommand);
            table = new DataTable();
            sda.Fill(table);
            myconn.Open();
            return table;
        }
        public void closeSql()
        {
            myconn.Close();
        }
        public string saveInto(string sql)
        {
            string message = "";
            myconn = new MySqlConnection(sqlconnection);
            SelectCommand = new MySqlCommand(sql, myconn);
            try
            {
                myconn.Open();
                myreader = SelectCommand.ExecuteReader();
                message = "Successful";
                myconn.Close();
            }
            catch (Exception ex)
            {
                message = "Somethings Wrong, \n" + ex.ToString();
            }
            return message;
        }
        
    }
}
