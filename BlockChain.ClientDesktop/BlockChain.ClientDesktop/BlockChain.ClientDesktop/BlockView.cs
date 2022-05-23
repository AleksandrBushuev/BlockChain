using System;

namespace BlockChain.ClientDesktop
{
    public class BlockView
    {
        public string UserId { get; set; }
        public int Number { get; set; }
        public DateTime TimeRecord { get; set; }
        public string Hash { get; set; }      
        public string Content { get; set; }
        public string PrevHash { get; set; }
    }
}
