using System.Text.RegularExpressions;

namespace Common.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            string emailValid = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(emailValid);
            return regex.IsMatch(email);
        }
    }
}
