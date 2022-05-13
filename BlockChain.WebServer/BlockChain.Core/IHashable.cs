using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Core
{
    public interface IHashable
    {
        string GetHash(HashAlgorithm hashAlgorithm);
    }
}
