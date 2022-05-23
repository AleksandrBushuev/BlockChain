using BlockChain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Core.Common
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
            TimeRecord = new DateTime(2009,01,03);
            UserId = Guid.Empty.ToString();            
            Data = new Data()
            {
                Content = "Первый выпуск биткоина",
                Signature = "Первый выпуск биткоина"
            };
            Hash = GetHash(HashAlgorithm);
        }

        internal Block(BlockDto blockDto)
        {
            Number = blockDto.Number;
            HashAlgorithm = SHA256.Create();
            TimeRecord = blockDto.TimeRecord;
            UserId = blockDto.UserId;
            PrevHash = blockDto.PrevHash;
            Data = new Data()
            {
                Content = blockDto.Data.Content,
                Signature = blockDto.Data.Signature
            };
            Hash = GetHash(HashAlgorithm);

            if(!Hash.Equals(blockDto.Hash))
                throw new ArgumentException("Нарушена целостность данных блока!");

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

        public BlockDto GetBlockDto()
        {
            var blockDto = new BlockDto()
            {
                Number = Number,
                Data = Data,
                Hash = Hash,
                PrevHash = PrevHash,
                TimeRecord = TimeRecord,
                UserId = UserId
            };
            return blockDto;
                         
        }

        public override bool Equals(object obj)
        {
            return obj is Block block &&
                   Number == block.Number &&                   
                   Hash == block.Hash &&
                   PrevHash == block.PrevHash &&
                   TimeRecord == block.TimeRecord &&
                   Data.Equals(block)&&                 
                   UserId == block.UserId;
        }
    }
}
