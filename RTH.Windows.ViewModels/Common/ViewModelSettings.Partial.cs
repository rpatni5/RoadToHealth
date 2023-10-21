using RTH.Helpers;
namespace RTH.Windows.ViewModels.Properties
{
    partial class Settings
    {
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TwitterUserId
        {
            get
            {
                return ((string)(this["TwitterUserId"])).Decrypt();
            }
            set
            {
                this["TwitterUserId"] = value.Encrypt();
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FacebookUserId
        {
            get
            {
                return ((string)(this["FacebookUserId"])).Decrypt();
            }
            set
            {
                this["FacebookUserId"] = value.Encrypt();
            }
        }
    }
}
