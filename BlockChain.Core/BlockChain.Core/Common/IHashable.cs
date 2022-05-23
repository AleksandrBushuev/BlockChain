using System.Security.Cryptography;

namespace BlockChain.Core.Common
{
    public interface IHashable
    {
        string GetHash(HashAlgorithm hashAlgorithm);
    }
}
