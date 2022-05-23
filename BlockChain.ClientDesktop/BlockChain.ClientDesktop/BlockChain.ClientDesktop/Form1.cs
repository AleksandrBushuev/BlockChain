using BlockChain.ClientDesktop.Extensions;
using BlockChain.ClientDesktop.Helpers;
using BlockChain.ClientDesktop.Keys;
using BlockChain.Core;
using BlockChain.Core.Clients;
using BlockChain.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockChain.ClientDesktop
{
    public partial class Form1 : Form
    {
        private IClientLogger _logger;
        private Client _client;
      

        public Form1()
        {
            InitializeComponent();           
            _logger = new FormLogger(textBoxLogger);
            txtAddress.Text = "https://localhost:44387/broadcast";
        }

        private async void btnAuth_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                _logger.LogDebug("Введите пароль!");
                return;
            }

          
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                _logger.LogDebug("Введите адрес сервера!");
                return;
            }

            if(!Regex.IsMatch(txtAddress.Text, @"^http(s)?://(\S|\s)*\S$"))
            {
                _logger.LogDebug("Введите адрес сервера с указанием протокола http[s]!");
                return;
            }

            var keys = await GetKeysAsync(txtPassword.Text);

            if (keys != null)
            {
                var user = new User(keys.GetPublicKey(), keys.GetSecretKey());
                _client = new Client(user, new Uri(txtAddress.Text), _logger);
                var connected =  await _client.ConnectAsync();

                if (connected)
                {
                    lbUser.Text = HashHelper.GetHashBits(user.Id);
                    _logger.LogDebug($"Подключение с сервером {txtAddress.Text} выполнено успешно");
                    await _client.PullAsync();
                    _client.BlockchainChanged += BlockchainChanged;
                }  
            }                     
        }


        private void BlockchainChanged()
        {
            var blockViews = _client.GetLocalBlockchain().ToBlockViews();
            ShowBlockchain(gridDataChain, blockViews);
        }


        private void ShowBlockchain(DataGridView gridView, List<BlockView> blockViews)
        {
            gridView.Rows.Clear();
            foreach (var block in blockViews)
            {
                gridView.Rows.Add(
                    block.Number,
                    block.TimeRecord.ToString("dd.MM.yy HH.mm"),
                    block.UserId,
                    block.Content,
                    block.Hash,
                    block.PrevHash
                );
            }
        }

        private async Task<KeyInfoRSA> GetKeysAsync(string password)
        {
            if(string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Пароль не должен быть пустым!");

            string path = Path.Combine(Directory.GetCurrentDirectory(), "keys.txt");
           
            if (!File.Exists(path))
            {
                var keys = KeysHelper.CreateKeys();
                _logger.LogDebug("Не удалось найти ключи! Будут сформированы новые ключи!");

                await KeysHelper.ExportAsync(keys, password, path);

                return keys;
            }

            try
            {
                var keys = await KeysHelper.ImportKeysAsync(password, path);
                return keys;
            }
            catch (CryptographicException ex)
            {
                _logger.LogError($"Не удалось сформировать ключи шифрования!", ex);
                return null;
            }        
        }
            

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!_client.Connected)
            {
                _logger.LogDebug("Операция прервана! Отсутствует подключение с сервером");
                return;
            }

            await _client.CommitAsync(textContent.Text);

        }
    }
}
