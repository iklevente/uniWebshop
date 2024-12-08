using System.Security.Cryptography;
using System.Text;

namespace UniWebShop.DataAccess
{
    public static class PasswordManagement
    {
        public static string GenerateSaltedAndHashedPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(64);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
            salt,
                100000,
                HashAlgorithmName.SHA512,
                64);
            return Convert.ToHexString(hash);
        }
        public static bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, 100000, HashAlgorithmName.SHA512, 64);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }
    }
}
