using BlockChain.Core;
using BlockChain.WebServer.Services;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BlockChain.WebServer
{
    public class ServerHub: Hub
    {
        private readonly IBlockChainService _blockChainService;

        public ServerHub(IBlockChainService blockChainService)
        {
            _blockChainService = blockChainService;
        } 

        [HubMethodName(Router.FullBlockChainRequest)]
        public async void GetBlockChain()
        {
            var blockchain = await GetBlockChainAsync();
            await Clients.Caller.SendAsync(Router.FullBlockChainResponce, blockchain);
        }

        [HubMethodName(Router.NewBlockChainRequest)]
        public async void NewBlockChainRequest(Block block)
        {
            var blockchain = GetBlockChainAsync();


        } 


        private async Task<Blockchain> GetBlockChainAsync()
        {
            var blockchain = await _blockChainService.GetBlockChainAsync();
            return blockchain;
        }
    }
}
