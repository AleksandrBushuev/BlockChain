using BlockChain.Core.Common;
using BlockChain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockChain.Core.Extensions
{
    public static class BlockchainExtension
    {
        public static List<BlockDto> ToListBlockDto(this Blockchain blockchain)
        {
            if (blockchain == null)
                return new List<BlockDto>();

            var listBlockchain = blockchain
              .Select(block => new BlockDto
              {
                  Number = block.Number,
                  UserId = block.UserId,
                  TimeRecord = block.TimeRecord,
                  Hash = block.Hash,
                  Data = block.Data,
                  PrevHash = block.PrevHash
              }).ToList();
            return listBlockchain;
        }

    }
}
