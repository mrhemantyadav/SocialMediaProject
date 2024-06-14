using System;


namespace SocialMediaApplication
{
    internal class ControlUserAndAdmin : MembersProperties
    {
        public  ControlUserAndAdmin()
        {

                Console.WriteLine("1.Login \t\t 2. Register");
                Choice = Convert.ToInt16(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                    Login login = new Login();
                        break;
                    case 2:
                        RegisterUser registerUser = new RegisterUser();
                        break;
                    default:
                        Console.WriteLine("somthing went wrong");
                        break;
                }        
            
        }

    }
}
