using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Utilitys.Utilitiess
{
    public static class Utilitiess
    {
        public static string RemoveDigitFromStart(string val)
        {
            var str = val.Substring(0, 1).ToCharArray();
            var strCode = (int)str[0];
            if (strCode >= 48 && strCode <= 57)
            {
                return RemoveDigitFromStart(val.Substring(1));
            }
            return val;
        }
        // Change first character to caps
        public static string FirstCharacterToUpper(string val)
        {
            var str = val.Substring(0, 1).ToCharArray();
            var strCode = (int)str[0];
            if (strCode >= 97)
            {
                var strCaps = strCode - 32;
                return (char)strCaps + val.Substring(1);
            }
            return val;
        }
        // Validates received email
        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        // Checks if value is within range
        private static bool IsWithinRange(int value, int minValue, int maxValue)
        {
            if (value >= minValue && value <= maxValue)
            {
                return true;
            }
            return false;
        }
        // Validate inputed value
        public static bool IsValid(string input, int minValue, int maxValue)
        {
            int value;
            bool success = int.TryParse(input, out value);
            if (success)
            {
                if (!IsWithinRange(value, minValue, maxValue))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\nPlease Input a number between {minValue} and {maxValue}: ");
                    Console.ResetColor();
                    success = false;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nPlease Input a valid number: ");
                Console.ResetColor();
            }
            return success;
        }
        // Generate hash
        public static List<byte[]> GenerateHash(this string password)
        {
            byte[] passwordSalt, passwordHash;
            // convert password to hash value and generate salt
            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hash.Key;
                passwordHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            var result = new List<byte[]>();
            result.Add(passwordHash);
            result.Add(passwordSalt);
            return result;
        }

        // compare password hash
        public static bool CompareHash(this string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hash = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var hashGenerated = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < hashGenerated.Length; i++)
                {
                    if (hashGenerated[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        // Method to generate account number
        public static string GenerateUniqueId()
        {
            string acctNum = string.Empty;
            Random rand = new Random();

            for (int i = 0; i < 1; i++)
            {
                acctNum += rand.NextInt64();
            }

            return acctNum;
        }
        // validate email
        public static bool IsEmailValid(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return true;
            else
                return false;
        }
    }
}
