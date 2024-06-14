using System;
using System.Data.SqlClient;

namespace SocialMediaApplication
{
    internal class RegisterUser : MembersProperties
    {

        
        SqlConnection _con = new SqlConnection("server = HEMANT\\SQLEXPRESS; integrated security = true; initial catalog =SocialMedia");

       // not declare SqlConnection class inside Method 
        //public void DbConnection()
        //{
        //    string str = "server = HEMANT\\SQLEXPRESS; integrated security = true; initial catalog =SocialMedia";
        //     _con = new SqlConnection(str);
        //}
        void Input()
        {
            try
            {
                Console.WriteLine("************* Register account ****************");

                Console.WriteLine("Enter Name");
                Full_Name = Console.ReadLine();

                Console.WriteLine("Enter E-Mail");
                Email_Address = Console.ReadLine();

                Console.WriteLine("Enter User Name");
                Surname = Console.ReadLine();

                Console.WriteLine("Enter country");
                Country = Console.ReadLine();

                Console.WriteLine("Enter Date of DOB yyyy-mm-dd");
                Date_of_birth = Console.ReadLine();

                Console.WriteLine("Enter Password");
                Password = Console.ReadLine();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        public RegisterUser ()
        {
            try
            {
                Input();    

                Query = "Insert into user_profile (full_name, email_address, surname, country, date_of_birth, password) values ('"+Full_Name+"','"+Email_Address+"','"+Surname+"','"+ Country + "','"+ Date_of_birth + "','"+ Password + "')";
                SqlCommand cmd = new SqlCommand(Query, _con);

                if (_con.State == System.Data.ConnectionState.Closed)
                {
                    _con.Open();
                }
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    Console.WriteLine("Successfully register account");
                    Console.WriteLine("1. View Profile \t 2. Create Post");
                    Choice = Convert.ToInt16(Console.ReadLine()); 
                    switch(Choice)
                    { 
                        case 1:
                            UserProfiles userProfiles = new UserProfiles();
                            userProfiles.UserProfile(Email_Address);
                            break;
                        case 2:

                            break;
                        default:
                            Console.WriteLine("Somthing went wrong ");
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("Somthing went wrong");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally {_con.Close(); }          
        }
    }
}
