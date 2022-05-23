using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BlockChain.ClientDesktop.Helpers
{
    public static class HashHelper
    {
        public static string GetHashBits(string strHash)
        {
            if (string.IsNullOrEmpty(strHash))
                return string.Empty;

            var bytes = Encoding.UTF8.GetBytes(strHash);
            
            using(var sha1 = SHA1.Create())
            {
                var hash = sha1.ComputeHash(bytes);
                var bits = BitConverter.ToString(hash);
                var result = Regex.Replace(bits, "-", string.Empty);
                return result;
            }
          
        }
    }
}
