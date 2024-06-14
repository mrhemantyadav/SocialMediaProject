namespace SocialMediaApplication
{
    internal class MembersProperties
    {
        protected int Id{ get; set; }
        protected string Email_Address{ get; set; }
        protected string Password { get; set; }
        protected string Country { get; set; }
        protected string Date_of_birth{ get; set; }
        protected string Full_Name { get; set; }
        protected string Surname { get; set; }
        protected short Choice { get; set; }
        protected string Query { get; set; }
        protected string LoginEmailUserName { get; set; }
        protected string ConfirmPassword { get; set; }
        protected string PasswordUpdate { get; set; }

        

        // create member for only User Post

        protected string WritePost {  get; set; }
        protected string Media_Location { get; set; } 



    }
}
