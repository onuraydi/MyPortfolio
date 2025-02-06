namespace MyPortfolio.WebApi.Entites.Identity
{
    public class RegisterModel
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }
    }
}
