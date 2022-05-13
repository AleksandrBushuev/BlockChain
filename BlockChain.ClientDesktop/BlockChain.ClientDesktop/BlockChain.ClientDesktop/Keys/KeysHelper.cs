using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlockChain.ClientDesktop.Keys
{
    public static class KeysHelper
    {
        public static async Task ExportAsync(KeyInfoRSA keys, string password, string path)
        {
            await Task.Run(() =>
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (var alg = GetSymmetricAlgorithm(password))
                    {
                        ICryptoTransform encryptor = alg.CreateEncryptor(alg.Key, alg.IV);
                        using (var csEncrypt = new CryptoStream(fs, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                var text = JsonSerializer.Serialize(keys);
                                swEncrypt.Write(text);
                            }

                        }
                    }
                }
            });            
        }

        public static async Task<KeyInfoRSA> ImportKeysAsync(string password, string path)
        {
            return await Task.Run(() =>
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (var alg = GetSymmetricAlgorithm(password))
                    {
                        ICryptoTransform decryptor = alg.CreateDecryptor(alg.Key, alg.IV);

                        using (CryptoStream csDecrypt = new CryptoStream(fs, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                var text = srDecrypt.ReadToEnd();
                                var keys = JsonSerializer.Deserialize<KeyInfoRSA>(text);
                                return keys;
                            }
                        }
                    }
                }
            });
        }

        public static KeyInfoRSA CreateKeys()
        {
            var rsa = RSA.Create();

            var keyInfo = new KeyInfoRSA();
            keyInfo.SetParameters(rsa.ExportParameters(true));
            return keyInfo;           
        }

        private static byte[] GetKeyPassword(string password)
        {            
            using (SHA256 sha = SHA256.Create())
            {
                var key = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return key;
            }
               
        }
                
        private static Aes GetSymmetricAlgorithm(string password)
        {
            byte[] key = GetKeyPassword(password);
            byte[] iv = key.Take(16).ToArray();

            var aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            return aesAlg;
        }
    }
}
