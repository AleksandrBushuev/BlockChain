using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Core
{
    public class Block : IHashable
    {
        public int Number { get; set; }
        public HashAlgorithm HashAlgorithm { get; private set; }
        public string Hash { get; private set; }
        public string PrevHash { get; private set; }
        public DateTime TimeRecord { get; private set; }
        public Data Data { get; private set; }
        public string UserId { get; private set; }

        internal Block()
        {
            Number = 0;
            HashAlgorithm = SHA256.Create();


        }

        public Block(User user, string content, Block prevBlock, HashAlgorithm hashAlgorithm)
        {
            if (!prevBlock.Hash.Equals(prevBlock.GetHash(prevBlock.HashAlgorithm)))
                throw new ArgumentException("Нарушена целостность данных предыдущего блока");

            HashAlgorithm = hashAlgorithm;

            Data data = new Data { Content = content };
            user.Sign(data, hashAlgorithm);

            PrevHash = prevBlock.Hash;
            TimeRecord = DateTime.Now;
            Data = data;
            UserId = user.Id;
            Hash = GetHash(hashAlgorithm);         
        }

        public string GetHash(HashAlgorithm hashAlgorithm)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(PrevHash);
            builder.Append(TimeRecord);
            builder.Append(Data.GetHash(hashAlgorithm));
            builder.Append(UserId);
            byte[] bytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(builder.ToString()));
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
