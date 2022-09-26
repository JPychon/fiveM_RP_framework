using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.Player
{
    public class User
    {
        public Character Character { get; set; }
        public Guid Id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public DateTime Created { get; set; }
    }
}
