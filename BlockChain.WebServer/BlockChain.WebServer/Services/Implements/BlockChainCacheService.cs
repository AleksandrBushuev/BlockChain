using BlockChain.Core;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain.WebServer.Services.Implements
{
    public class BlockChainCacheService: IBlockChainCacheService
    {
        private const string BLOCK_CHAIN_KEY = "chainKey";
        private readonly IMemoryCache _cache;
        private object stub = new object();
                
        public BlockChainCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Blockchain GetBlockChain()
        {
            lock (stub)
            {
                var blockchain = _cache.Get<Blockchain>(BLOCK_CHAIN_KEY);
                return blockchain;
            }
        }

        public void SetBlockChain(Blockchain blockchain)
        {
            lock (stub)
            {
                _cache.Set<Blockchain>(BLOCK_CHAIN_KEY, blockchain);
            }
        }

    }
}
