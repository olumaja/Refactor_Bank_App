using System;
using System.Text.RegularExpressions;

namespace Utility
{
    public class Validator
    {
        public bool IsValideEmail(string userEmail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(userEmail);
            return match.Success;
        }

    }
}
