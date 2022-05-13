using BlockChain.ClientDesktop.Keys;
using BlockChain.Core;
using System;
using System.IO;
using System.Security.Cryptography;
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
                    _logger.LogDebug($"Подключение с сервером {txtAddress.Text} выполнено успешно");

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
        
    }
}
