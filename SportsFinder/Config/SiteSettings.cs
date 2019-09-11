namespace SportsFinder.Config
{
    //Not sure where to put this class, So I just added it to Models directory.
    public class SiteSettings
    {
        public bool RegistrationEnabled { get; set; }
        public bool NavigationLoginEnabled { get; set; } //Show navigation if a user is not logged in.
        public bool TwoFactorAuthenticationEnabled { get; set; }
        public AdminsSettings Admin { get; set; }
    }

    public class AdminsSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}