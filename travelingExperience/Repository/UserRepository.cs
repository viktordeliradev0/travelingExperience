using travelingExperience.DbConnetion;
using Scrypt;
using travelingExperience.Entity;

namespace travelingExperience.Repository
{
    public class UserRepository
    {
        private AppDbContext context;
        public UserRepository(AppDbContext ob)
        {
            context = ob;
        }
        public User FindByUsernameAndPassword(string username, string password)
        {
           ScryptEncoder encoder = new ScryptEncoder();
            foreach (var user in context.Users)
            {
                if (user.Name.Equals(username) && encoder.Compare(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }
        public bool findByEmail(string email)
        {
            return context.Users.FirstOrDefault(x => x.Email == email) != null ? true : false;
        }
    }
}

