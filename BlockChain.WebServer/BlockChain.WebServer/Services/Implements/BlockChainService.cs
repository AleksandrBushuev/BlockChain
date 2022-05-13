using BlockChain.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BlockChain.WebServer.Services.Implements
{
    public class BlockChainService: IBlockChainService
    {
        private readonly IBlockChainCacheService _cacheService;
        private readonly ILogger<BlockChainService> _logger;
        public BlockChainService(ILogger<BlockChainService> logger, IBlockChainCacheService cacheService)
        {
            _cacheService = cacheService;
            _logger = logger;
        }

        public Task<Blockchain> GetBlockChainAsync()
        {
            return Task.Run(() =>
            {
               var blockchain = _cacheService.GetBlockChain();
               return blockchain;
            });
        }

        public bool AddBlock(Block block)
        {
            var blockchain = _cacheService.GetBlockChain();
            try
            {
                blockchain.PushBlock(block);
                _cacheService.SetBlockChain(blockchain);
                return true;
            }
            catch(ArgumentException ex)
            {
                _logger?.LogError(ex.Message, ex);
                return false;
            }         
                          
        }

    }
}
