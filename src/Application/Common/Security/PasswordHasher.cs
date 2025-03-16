namespace Application.Common.Security
{
    public class PasswordHasher
    {
        private const int WorkFactor = 12; 

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
            catch
            {
                return false;
            }
        }

        public static bool NeedsRehash(string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.PasswordNeedsRehash(hashedPassword, WorkFactor);
            }
            catch
            {
                return true;
            }
        }
    }
} 