using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace User_Register_Login_Dotnet.Models
{
    public class Dbcontext
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        public bool Add(UserModel um)
        {
            string str = "insert into users values('" + um.Emailid + "','" + um.Password + "','" + um.Name + "')";
            SqlCommand cmd = new SqlCommand(str, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            int a = cmd.ExecuteNonQuery();
            if(a>=1)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

                
        public bool Update(UserModel um)
        {
            string str = "update users set emailId='"+um.Emailid + "',password='" + um.Password + "',name='" + um.Name + "'where id='"+um.ID+"'";
            SqlCommand cmd = new SqlCommand(str, con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<UserModel>GetUser()
        {
            List<UserModel> lst = new List<UserModel>();
            SqlCommand cmd = new SqlCommand("select * from users", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new UserModel
                {
                    ID = Convert.ToInt32(dr[0]),
                    Emailid = Convert.ToString(dr[1]),
                    Password = Convert.ToString(dr[2]),
                    Name = Convert.ToString(dr[3])

                }
                );
            }

            return lst;
        }



        public List<UserModel> GetbyId(string email)
        {
            List<UserModel> lst = new List<UserModel>();
            SqlCommand cmd = new SqlCommand("select * from users where emailId ='"+email +"'", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new UserModel
                {
                    ID = Convert.ToInt32(dr[0]),
                    Emailid = Convert.ToString(dr[1]),
                    Password = Convert.ToString(dr[2]),
                    Name = Convert.ToString(dr[3])

                }
                );
            }

            return lst;
        }
    }
}