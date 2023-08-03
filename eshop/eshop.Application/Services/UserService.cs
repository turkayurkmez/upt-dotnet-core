using eshop.Entities;

namespace eshop.Application.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>()
        {
             new(){ Id=1, Name="Türkay", Email="t@urkmez.com", Password="123", Role="admin", UserName="turkay"},
             new(){ Id=2, Name="Fatih", Email="f@upt.com", Password="123", Role="editor", UserName="fatih"},
             new(){ Id=3, Name="Kadir", Email="k@upt.com", Password="123", Role="client", UserName="kadir"},

        };
        public User ValidateUser(string username, string password)
        {
            return _users.SingleOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
