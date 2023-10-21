using RTH.Helpers;
using System.Linq;
using System.Security;

namespace RTH.Windows.Views.Properties
{
    partial class Settings
    {
        public SecureString SecurePwd
        {
            get
            {
                string temp = ((string)this["EncryptedPwd"]).Decrypt();
                var returnVal = new SecureString();
                temp.All(ch =>
                {
                    returnVal.AppendChar(ch);
                    return true;
                });
                temp = null;
                return returnVal;
            }
        }

        public void SaveSecurePwd(string value)
        {
            this["EncryptedPwd"] = value.Encrypt();
        }
    }
}
