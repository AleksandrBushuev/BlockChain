using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace BlockChain.ClientDesktop.Keys
{
    public class KeyInfoRSA
    {      
        [JsonPropertyName("D")]
        public byte[] D { get; set; }

        [JsonPropertyName("DP")]
        public byte[] DP { get; set; }

        [JsonPropertyName("DQ")]
        public byte[] DQ { get; set; }

        [JsonPropertyName("Exponent")]
        public byte[] Exponent { get; set; }

        [JsonPropertyName("InverseQ")]
        public byte[] InverseQ { get; set; }

        [JsonPropertyName("Modulus")]
        public byte[] Modulus { get; set; }

        [JsonPropertyName("P")]
        public byte[] P { get; set; }

        [JsonPropertyName("Q")]
        public byte[] Q { get; set; }

       
        public RSAParameters GetPublicKey()
        {
            var publicKey = new RSAParameters()
            {                
                Exponent = Exponent,              
                Modulus = Modulus               
            };
            return publicKey;
        }

        public RSAParameters GetSecretKey()
        {
            var secretKey = new RSAParameters()
            {
                D = D,
                DP = DP,
                DQ = DQ,
                Exponent = Exponent,
                InverseQ = InverseQ,
                Modulus = Modulus,
                P = P,
                Q = Q
            };
            return secretKey;
        }

        public void SetParameters(RSAParameters parameters)
        {
            D = parameters.D;
            DP = parameters.DP;
            DQ = parameters.DQ;
            Exponent = parameters.Exponent;
            InverseQ = parameters.InverseQ;
            Modulus = parameters.Modulus;
            P = parameters.P;
            Q = parameters.Q;
        }
    }
}
