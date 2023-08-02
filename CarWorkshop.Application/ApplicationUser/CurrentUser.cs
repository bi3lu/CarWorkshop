namespace CarWorkshop.Application.ApplicationUser
{
    public class CurrentUser
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public CurrentUser(string id, string email)
        {
            Id = id;
            Email = email;
        }

    }
}
