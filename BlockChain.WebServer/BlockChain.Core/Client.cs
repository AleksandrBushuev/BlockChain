using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Core
{
    public class Client
    {
        private readonly User _user;
        private readonly IClientLogger _logger;

        private Blockchain _localBlockchain;

        private HubConnection _connection;

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
            if (_connection.State == HubConnectionState.Connected)
                return true;

            try
            {
                _logger.LogDebug("StartAsync");
                await _connection.StartAsync();
                _logger.LogDebug("Загрузка цепочки блоков");
                await LoadGlobalBlockChainAsync();
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
            Block block = new Block(_user, content, _localBlockchain.BlockLast, SHA256.Create());
            await _connection.SendAsync(Router.NewBlockChainRequest, block);
        }

        public async Task LoadGlobalBlockChainAsync()
        {         
            await _connection.SendAsync(Router.FullBlockChainRequest);          
        }

        private void RegisterExchange()
        {
            _connection.On<Blockchain>(Router.FullBlockChainResponce, FullBlockChainResponceHandler);
            _connection.On<Block>(Router.NewBlockChainResponce, NewBlockChainResponceHandlerAsync);
        }

        private void FullBlockChainResponceHandler(Blockchain blockchain)
        {
            _localBlockchain = blockchain;
        }

        private async void NewBlockChainResponceHandlerAsync(Block block)
        {
            try
            {
                _localBlockchain.PushBlock(block);
            }
            catch (ArgumentNullException ex)
            {
                await LoadGlobalBlockChainAsync();
            }
            catch (ArgumentException ex)
            {
                await LoadGlobalBlockChainAsync();
            }
        }
                
    }
}
