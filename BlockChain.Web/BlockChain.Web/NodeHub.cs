using BlockChain.Core.Clients;
using BlockChain.Core.Common;
using BlockChain.Core.Dtos;
using BlockChain.Core.Extensions;
using BlockChain.Web.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BlockChain.Web
{
    public class NodeHub : Hub
    {     
        private readonly IBlockChainService _blockChainService;
        private readonly ILogger<NodeHub> _logger;

        public NodeHub(ILogger<NodeHub> logger, IBlockChainService blockChainService)
        {
            _blockChainService = blockChainService;
            _logger = logger;
        }

        [HubMethodName(Router.FullBlockChainRequest)]
        public async Task GetBlockChain()
        {
            var blockchain =  await _blockChainService.GetBlockChainAsync();           
            var listBlockchain = blockchain.ToListBlockDto();         
            await Clients.Caller.SendAsync(Router.FullBlockChainResponse, listBlockchain);
        }

        [HubMethodName(Router.AddBlockRequest)]
        public  async void AddBlock(BlockDto blockDto)
        {

           var isAdded = _blockChainService.AddBlock(blockDto);
           
            if(isAdded)
                await Clients.All.SendAsync(Router.AddBlockResponse, blockDto);
                     
        }

    }
}
