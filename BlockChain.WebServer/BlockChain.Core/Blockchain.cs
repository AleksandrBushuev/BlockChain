using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockChain.Core
{
    public class Blockchain
    {
        private List<Block> _blockchain = new List<Block>();

        public Block BlockLast => _blockchain.Last();

        public Blockchain()
        {
            Block block = new Block();
        }

        public void PushBlock(Block block)
        {
            if (BlockLast != null)
            {
                throw new ArgumentNullException("Цепочка данных не объявлена");
            }

            if (!BlockLast.Hash.Equals(block.PrevHash))
            {
                throw new ArgumentException($"Нарушение целостности данных. Хэш предыдущего блока не соответствует хэшу в добавляемом блоке.") ;
            }          
            block.Number = BlockLast.Number + 1;
            _blockchain.Add(block);            
        }


        
    }
}
