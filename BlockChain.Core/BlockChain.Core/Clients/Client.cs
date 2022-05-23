using BlockChain.Core.Common;
using BlockChain.Core.Dtos;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BlockChain.Core.Clients
{
    public class Client
    {
        private readonly User _user;
        private readonly IClientLogger _logger;
             
        private Blockchain _blockchainGlobal;

        private HubConnection _connection;

        #pragma warning disable CS8632 
        public event Action? BlockchainChanged;
        #pragma warning restore CS8632 

        public bool Connected => _connection.State == HubConnectionState.Connected;

        public Client(User user, Uri host, IClientLogger logger)
        {
            _logger = logger;
            _user = user;
            _connection = new HubConnectionBuilder()
                .WithUrl(host)
                .Build();

            _connection.Closed += async (error) =>
            {
                if (_logger != null)
                    _logger.LogError("Закрыто соединение с сервером", error);
                await ConnectAsync();
            };

            RegisterExchange();
        }

        public async Task<bool> ConnectAsync()
        {
            if (Connected)
                return true;

            try
            {                
                await _connection.StartAsync();
                return true;
            }
            catch(Exception ex)
            {
                if (_logger != null)
                    _logger.LogError("Не удалось выполнить подключение к серверу", ex);
                return false;
            }           
        }
        
        public async Task CommitAsync(string content)
        {
            try
            {
                var block = new Block(_user, content, _blockchainGlobal.BlockLast, SHA256.Create());
                await _connection.SendAsync(Router.AddBlockRequest, block.GetBlockDto());
            }
            catch(ArgumentException ex)
            {
                _logger.LogError(ex.Message);
            }   
        }        

        public async Task PullAsync()
        {            
            await _connection.SendAsync(Router.FullBlockChainRequest);          
        }

        public Blockchain GetLocalBlockchain()
        {
            return _blockchainGlobal;
        }

        private void RegisterExchange()
        {
            _connection.On<List<BlockDto>>(Router.FullBlockChainResponse, FullBlockChainResponceHandler);
            _connection.On<BlockDto>(Router.AddBlockResponse, NewBlockChainResponceHandlerAsync);
        }

        private void FullBlockChainResponceHandler(List<BlockDto> blocks)
        {
            _blockchainGlobal = new Blockchain(blocks);
            BlockchainChanged?.Invoke();
        }

        private async void NewBlockChainResponceHandlerAsync(BlockDto block)
        {
            try
            {
                _blockchainGlobal.PushBlock(block);
                BlockchainChanged?.Invoke();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                await PullAsync();
            }
        }
                
    }
}
