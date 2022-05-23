using BlockChain.Core.Common;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Core.Dtos
{
    public class BlockDto
    {
        public int Number { get; set; }       
        public string Hash { get; set; }
        public string PrevHash { get; set; }
        public DateTime TimeRecord { get;  set; }
        public Data Data { get;  set; }
        public string UserId { get;  set; }
    }
}
