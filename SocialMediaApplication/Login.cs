using System;
using System.Data.SqlClient;

namespace SocialMediaApplication
{
    internal class Login : MembersProperties
    {
        SqlConnection _con = new SqlConnection("server = HEMANT\\SQLEXPRESS; integrated security = true; initial catalog =SocialMedia");
        public void InputLoginUser() 
        {
            try
            {
                Console.WriteLine("Enter email or username :");
                LoginEmailUserName = Console.ReadLine();

                Console.WriteLine("Enter Password : ");
                Password = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Login() 
        {
                InputLoginUser();
            try
            {

                Query = "select *from user_profile where email_address = '" + LoginEmailUserName + "' OR surname = '" + LoginEmailUserName + "' AND password ='" + Password + "'";

                SqlCommand cmd = new SqlCommand(Query, _con);

                if (_con.State == System.Data.ConnectionState.Closed)
                {
                    _con.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();

                //if ((dr["email_address"] != null) || (dr["password"]) != null
                
                if(dr.Read())
                {
                    string emails =(string) dr["email_address"];
                    Console.WriteLine(emails);
                    Console.WriteLine("Login Successfully");
                    Console.WriteLine("1.Profile \t\t 2. Create Post ");
                    Choice =Convert.ToInt16(Console.ReadLine());

                    switch (Choice)
                    {
                        case 1:
                            UserProfiles userProfiles = new UserProfiles();
                            userProfiles.UserProfile(emails);
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
                    Console.WriteLine("Check email or username and password");
                    Console.WriteLine("1.Forget Password \t\t 2.Register");
                    short ChoiceInside = Convert.ToInt16(Console.ReadLine());
                    if (ChoiceInside == 1)
                    {
                        Update update = new Update();
                        update.ForgetPass();
                    }
                    else if (ChoiceInside == 2)
                    {
                        RegisterUser registerUser = new RegisterUser();
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally { _con.Close();}
        }

    }
}
