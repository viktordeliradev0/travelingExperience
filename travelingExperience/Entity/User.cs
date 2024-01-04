using System.ComponentModel.DataAnnotations;

namespace travelingExperience.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public string SName { get; set; }
       
        public string UserName { get; set; }
        
        public string Email { get; set; }
       
        public string Password { get; set; }
        
        public string Number { get; set; }
        
        public int Age { get; set; }

        public User(string name,string sname, string username,string email,string password,string phoneN,int age)
        {
            this.Name = name;
            this.SName = sname;
            this.UserName = username;
            this.Email = email;
            this.Password = password;
            this.Number = phoneN;
            this.Age = age;
        }

        public User()
        {
            //Parameterless constructor
        }

    }
}
