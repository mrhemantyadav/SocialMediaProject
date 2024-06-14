using System;
using System.Data.SqlClient;


namespace SocialMediaApplication
{
    internal class ConnectionDb
    {
        public void ConnectiondbCon()
        {
            string str = "server = HEMANT\\SQLEXPRESS; integrated security = true; initial catalog = SocialMedia ";
            SqlConnection con = new SqlConnection(str);
           // Console.WriteLine(_con);

            //if (_con.State == System.Data.ConnectionState.Closed)
            //{
            //    _con.Open();
            //    Console.WriteLine("Connection successfully Create");
            //}
            //else 
            //{
            //    Console.WriteLine("something went wrong ");
            //}
        }
    

    }
}
