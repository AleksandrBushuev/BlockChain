using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Core.Helpers
{
    public static class SecretHelper
    {
        public static byte[] GetSignature(byte[] data, HashAlgorithm hashAlgorithm, RSAParameters secretKey)
        {
            var cryptoService = new RSACryptoServiceProvider();
            cryptoService.ImportParameters(secretKey);
            byte[] signBytes = cryptoService.SignData(data, hashAlgorithm);
            return signBytes;
        }

        public static bool VerifySignature(byte[] data, byte[] signature,  HashAlgorithm hashAlgorithm, RSAParameters publicKey)
        {
            var cryptoService = new RSACryptoServiceProvider();
            cryptoService.ImportParameters(publicKey);
            var result = cryptoService.VerifyData(data, hashAlgorithm, signature);
            return result;
        }


    }
}
