using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects.JSON
{
    public class TwitterAuthToken
    {
        public string ScreenName { get; set; }
        //
        // Summary:
        //     Gets or sets the token.
        public string Token { get; set; }
        //
        // Summary:
        //     Gets or sets the token secret.
        public string TokenSecret { get; set; }
        //
        // Summary:
        //     Gets or sets the user ID.
        public string UserId { get; set; }
        //
        // Summary:
        //     Gets or sets the verification string. This is required when overriding the application's
        //     callback url.
        public string VerificationString { get; set; }
    }
}
