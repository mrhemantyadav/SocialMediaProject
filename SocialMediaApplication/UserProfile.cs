using System;
using System.Data.SqlClient;

namespace SocialMediaApplication
{
    internal class UserProfiles: MembersProperties
    {
        string emailAdds;
        SqlConnection _con = new SqlConnection("server = HEMANT\\SQLEXPRESS; integrated security = true; initial catalog = SocialMedia");
        public void UserProfile(string email)
        {
            try
            {
                this.emailAdds = email;
                Console.WriteLine("******************* Welcome ******************");

                Query = "select * from user_profile where email_address = '"+emailAdds+"'";
                SqlCommand cmd = new SqlCommand(Query, _con);

                if (_con.State == System.Data.ConnectionState.Closed)
                { 
                    _con.Open();                
                }
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) 
                {
                    Console.WriteLine("Id : "+dr["id"]+"\t\t\t\t\t Name : " + dr["full_name"]);
                    Console.WriteLine("email : " + dr["email_address"] + "\t\t UserName : " + dr["surname"]);
                    Console.WriteLine("country : " + dr["country"] + "\t\t\t\t date_of_birth : " + dr["date_of_birth"]);
                }
             
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally { _con.Close(); }




        }
    }
}
