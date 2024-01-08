using travelingExperience.DbConnetion;
using Scrypt;
using travelingExperience.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using travelingExperience.Models;

namespace travelingExperience.Repository
{
    public class UserRepository<T> 
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

