using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace BantayBahaSMS.Class
{
    class Phonebook
    {

        MySqlConnection con;
        MySqlCommand cmd;
        string query;



        string lname, fname, mname, gender, contactNo;


        public Phonebook()
        {

        }

        public Phonebook(string lname, string fname, string mname, string gender, string contactNo)
        {
            Lname = lname;
            Fname = fname;
            Mname = mname;
            Gender = gender;
            ContactNo = contactNo;
           
        }


        public string Lname { get => lname; set => lname = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Mname { get => mname; set => mname = value; }
        public string Gender { get => gender; set => gender = value; }
        public string ContactNo { get => contactNo; set => contactNo = value; }



        public void insert()
        {
            con = Connection.con();
            con.Open();
            query = "insert into phonebook set lname=?lname, fname=?fname, mname=?mname, gender=?gender, contactNo=?contact";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("?lname", Lname);
            cmd.Parameters.AddWithValue("?fname", Fname);
            cmd.Parameters.AddWithValue("?mname", Mname);
            cmd.Parameters.AddWithValue("?gender", Gender);
            cmd.Parameters.AddWithValue("?contact", ContactNo);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }


        public void update(int id)
        {
            con = Connection.con();
            con.Open();
            query = "update phonebook set lname=?lname, fname=?fname, mname=?mname, gender=?gender, contactNo=?contact where phonebookID=?id";
            cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("?lname", Lname);
            cmd.Parameters.AddWithValue("?fname", Fname);
            cmd.Parameters.AddWithValue("?mname", Mname);
            cmd.Parameters.AddWithValue("?gender", Gender);
            cmd.Parameters.AddWithValue("?contact", ContactNo);
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
            query = "delete from phonebook where phonebookID=?id";
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
            query = "select * from phonebook";
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
                query = "select * from phonebook where phonebookID = ?id";
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

            public DataTable search(string lname, string fname)
        {
            DataTable dt = new DataTable();

            con = Connection.con();
            con.Open();
            query = "select * from phonebook where lname like ?lname and fname like ?fname";
            cmd = new MySqlCommand(query, con);
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
