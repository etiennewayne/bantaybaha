using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BantayBahaSMS.Class
{
    class User
    {

        MySqlConnection con;
        MySqlCommand cmd;
        string query;


        //private string username, pwd, fname, mname, position, gender;


        public User()
        {

        }

        public User(string username, string pwd, string lname, string fname, string mname,  string gender)
        {
            this.username = username;
            this.pwd = pwd;
            this.lname = lname;
            this.fname = fname;
            this.mname = mname;
           
            this.gender = gender;
        }


        public string username { set; get; }
        public string pwd { set; get; }
        public string lname { set; get; }
        public string fname { set; get; }

        public string mname { set; get; }
      //  public string position { set; get; }
        public string gender { set; get; }


        public void insert()
        {
            con = Connection.con();
            con.Open();
            query = "insert into users set username=?uname, pwd=?pwd, lname=?lname, fname=?fname, mname=?mname, gender=?gender";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("?uname", username);
            cmd.Parameters.AddWithValue("?pwd", pwd);
            cmd.Parameters.AddWithValue("?lname", lname);
            cmd.Parameters.AddWithValue("?fname", fname);
            cmd.Parameters.AddWithValue("?mname", mname);
            //cmd.Parameters.AddWithValue("?pos", position);
            cmd.Parameters.AddWithValue("?gender", gender);
           
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }


        public void update(int id)
        {
            con = Connection.con();
            con.Open();
            query = "update users set username=?uname, pwd=?pwd, lname=?lname, fname=?fname, mname=?mname,  gender=?gender where userid =?id";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("?uname", username);
            cmd.Parameters.AddWithValue("?pwd", pwd);
            cmd.Parameters.AddWithValue("?lname", lname);
            cmd.Parameters.AddWithValue("?fname", fname);
            cmd.Parameters.AddWithValue("?mname", mname);
           // cmd.Parameters.AddWithValue("?pos", position);
            cmd.Parameters.AddWithValue("?gender", gender);
            cmd.Parameters.AddWithValue("?id", id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }


        public void delete(int id)
        {
            con = Connection.con();
            con.Open();
            query = "delete from users where userid=?id";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("?id", id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }

        public DataTable all()
        {
            DataTable dt = new DataTable();

            con = Connection.con();
            con.Open();
            query = "select * from users";
            cmd = new MySqlCommand(query, con);
            // cmd.Parameters.AddWithValue("?id", id);
            MySqlDataAdapter adptr = new MySqlDataAdapter(cmd);
            adptr.Fill(dt);
            adptr.Dispose();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();

            return dt;
        }


        public DataTable find(int id)
        {
            DataTable dt = new DataTable();

            con = Connection.con();
            con.Open();
            query = "select * from users where userid = ?id";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("?id", id);
            MySqlDataAdapter adptr = new MySqlDataAdapter(cmd);
            adptr.Fill(dt);
            adptr.Dispose();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();

            return dt;
        }

        public DataTable search(string username, string lname, string fname)
        {
            DataTable dt = new DataTable();

            con = Connection.con();
            con.Open();
            query = "select * from users where username like ?uname and lname like ?lname and fname like ?fname";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("?uname", username + "%");
            cmd.Parameters.AddWithValue("?lname", lname + "%");
            cmd.Parameters.AddWithValue("?fname", fname + "%");
            MySqlDataAdapter adptr = new MySqlDataAdapter(cmd);
            adptr.Fill(dt);
            adptr.Dispose();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();

            return dt;
        }


    }
}
