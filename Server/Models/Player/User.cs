using System;

namespace Server.Models
{
    public class User 
    {
        public Character Character { get; set; }
        public Guid Id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public DateTime Created { get; set; }



        public User()
        {
            this.Id = Guid.NewGuid();
            this.Created = DateTime.UtcNow;
        }

    }
}
