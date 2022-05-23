using BlockChain.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Core.Common
{
    public abstract class Signer
    {
        private readonly RSAParameters _secretKey;
        public Signer (RSAParameters secretKey)
        {
            _secretKey = secretKey;
        }

        public void Sign(Data data, HashAlgorithm hashAlgorithm)
        {
            byte[] content = Encoding.UTF8.GetBytes(data.Content);
            byte[] signature = SecretHelper.GetSignature(content, hashAlgorithm, _secretKey);
            data.Signature = Encoding.UTF8.GetString(signature);
        }
    }
}
