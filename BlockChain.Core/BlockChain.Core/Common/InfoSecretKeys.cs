using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Core.Common
{
    public class InfoSecretKeys
    {
        public RSAParameters SecretKey { get; set; }
        public RSAParameters PublicKey { get; set; }
    }
}
