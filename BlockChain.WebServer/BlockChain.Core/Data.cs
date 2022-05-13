using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Core
{
    public class Data: IHashable
    {        
        public string Content { get; set; }
        public string Signature { get; set; }

        public string GetHash(HashAlgorithm hashAlgorithm)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Content);
            builder.Append(Signature);            
            byte[] bytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(builder.ToString()));
            return Encoding.UTF8.GetString(bytes);
        }
    }
}