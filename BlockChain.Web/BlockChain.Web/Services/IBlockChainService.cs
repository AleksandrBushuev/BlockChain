using BlockChain.Core;
using BlockChain.Core.Common;
using BlockChain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain.Web.Services
{
    public interface IBlockChainService
    {
        bool AddBlock(BlockDto block);
        public Task<Blockchain> GetBlockChainAsync();
    }
}
