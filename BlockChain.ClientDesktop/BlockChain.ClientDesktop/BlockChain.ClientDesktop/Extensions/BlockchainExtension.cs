using BlockChain.ClientDesktop.Helpers;
using BlockChain.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.ClientDesktop.Extensions
{
    public static class BlockchainExtension
    {
        public static List<BlockView> ToBlockViews (this Blockchain blockchain)
        {
            if (blockchain == null)
                return new List<BlockView>();
                      
            var blockViews = blockchain
                .Select(block => new BlockView() {
                    UserId = HashHelper.GetHashBits(block.UserId),
                    Number = block.Number,
                    Hash = HashHelper.GetHashBits(block.Hash),
                    TimeRecord = block.TimeRecord,
                    Content = block.Data.Content,
                    PrevHash = HashHelper.GetHashBits(block.PrevHash)
                }).ToList();

            return blockViews;
        }

        
    }
}
