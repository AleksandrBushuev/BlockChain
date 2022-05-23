using BlockChain.Core.Common;
using Microsoft.Extensions.Caching.Memory;


namespace BlockChain.Web.Services.Implements
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
                if (blockchain == null)
                {
                    blockchain = new Blockchain();
                    SetBlockChain(blockchain);
                }

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
