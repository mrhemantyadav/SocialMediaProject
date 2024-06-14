using System;
using System.Data.SqlClient;


namespace SocialMediaApplication
{
    internal class Update : MembersProperties
    {
        SqlConnection _con = new SqlConnection("server = HEMANT\\SQLEXPRESS; integrated security = true; initial catalog = SocialMedia");
        public void InputNewPass()
        {
            try
            {
                Console.WriteLine("Enter Emmail or Username :");
                LoginEmailUserName = Console.ReadLine();

                Console.WriteLine("Enter new password :");
                Password = Console.ReadLine();

                Console.WriteLine("confirm Password : ");
                ConfirmPassword = Console.ReadLine();

                if (Password.Equals(ConfirmPassword))
                {
                    PasswordUpdate = Password;
                }
                else
                {
                    Console.WriteLine("Password not match: try again ");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void ForgetPass()
        {
            try
            {
                InputNewPass();

                Query = "update user_profile set password = '" + PasswordUpdate + "' where email_address ='" + LoginEmailUserName + "' OR surname ='" + LoginEmailUserName + "' ";

                SqlCommand cmd = new SqlCommand(Query, _con);
                if (_con.State == System.Data.ConnectionState.Closed)
                {
                    _con.Open();
                }
                int affectedRow = cmd.ExecuteNonQuery();
                if (affectedRow > 0)
                {
                    Console.WriteLine("Password updated ");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { _con.Close(); }
        }
    }
}
