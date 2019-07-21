using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoor
{
    public class UserBox
    {
        private String username;
        private String password;

        public UserBox()
        {

        }

        public UserBox(String Username, String Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
