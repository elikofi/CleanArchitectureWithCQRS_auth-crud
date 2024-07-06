using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Constants
{
    public static class ConstantResponses
    {
        //Registration constants
        public const string RegisteredSuccessfully = "User Registered Successfully.";
        public const string FailedRegistration = "Failed to register user:";

        //Role management constants
        public const string UsernameNotFound = "The username provided doesn't exist.";
        public const string NewAdmin = " is now an Admin.";

    }
}
