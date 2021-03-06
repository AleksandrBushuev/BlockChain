using BlockChain.Core.Helpers;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Core.Common
{
    public class User: Signer
    {       
        public string Id { get;}

        public RSAParameters PublicKey { get; private set; }

        public User(RSAParameters publicKey, RSAParameters secretKey) : base(secretKey)
        {            
            PublicKey = publicKey;          

            using(HashAlgorithm hashAlgorithm = SHA256.Create())
            {
                var bytes = publicKey.Modulus.Union(publicKey.Exponent).ToArray();
                byte[] hash = hashAlgorithm.ComputeHash(bytes);
                Id = Encoding.UTF8.GetString(hash);
            }
        }             

        public void VerifySignature(Data data, HashAlgorithm hashAlgorithm)
        {
            byte[] content = Encoding.UTF8.GetBytes(data.Content);
            byte[] signature = Encoding.UTF8.GetBytes(data.Signature);
            SecretHelper.VerifySignature(content, signature, hashAlgorithm, PublicKey);
        }
                       
    }
}
