using CredentialManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDoor
{
    public class UserCredentials
    {
        private String targetName;

        public string TargetName { get => targetName; set => targetName = value; }

        public UserCredentials()
        {
            this.targetName = Assembly.GetEntryAssembly().GetName().Name;
        }
        
        public bool SaveUserCredentials(String Username, String Password)
        {
            try
            {
                using (var cred = new Credential())
                {
                    cred.Username = Username;
                    cred.Password = Password;
                    cred.Target = this.targetName;
                    cred.Type = CredentialType.Generic;
                    cred.PersistanceType = PersistanceType.LocalComputer;
                    cred.Save();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public UserBox GetUserCredentials()
        {
            var cred = new Credential();
            cred.Target = this.targetName;

            if (!cred.Load())
            {
                return null;
            }

            return new UserBox(cred.Username, cred.Password);
        }

        public bool DeleteUserCredentials()
        {
            using (var cred = new Credential() { Target = targetName })
            {
                return cred.Delete();
            }
        }


    }
}
