using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BantayBahaSMS
{
    class Connection
    {

        static string host = Properties.Settings.Default.server;
        static string dbuser = Properties.Settings.Default.dbuser;
        static string dbpwd = Properties.Settings.Default.dbpwd;
        static string database = Properties.Settings.Default.database;

        public static MySqlConnection con()
        {


            //string[] lines = System.IO.File.ReadAllLines(Application.StartupPath + "/config.txt");
            // return new MySqlConnection(lines[0] + ";" + lines[1] + ";user=root;password=''");
            return new MySqlConnection("server=" + host + ";database=" + database + ";user=" + dbuser + ";password=" + dbpwd);
        }


        public static string getConnectionString()
        {
            return "server=" + host + ";database=" + database + ";user=" + dbuser + ";password=" + dbpwd;
        }


    }
}
