using BlockChain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain.WebServer.Services
{
    public interface IBlockChainService
    {
        public Task<Blockchain> GetBlockChainAsync();
    }
}
