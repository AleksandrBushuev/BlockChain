using BlockChain.Core.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BlockChain.Core.Common
{
    public class Blockchain: IEnumerable<Block>
    {
        private List<Block> _blockchain;

        public Block BlockLast => _blockchain.Last();

        internal Blockchain(List<BlockDto> blocks)
        {    
            var blockFirst = blocks.FirstOrDefault(block => block.Number == 0); // нужна детальная проверка целосности
            if (blockFirst == null) 
                throw new ArgumentException("Нарушена целостность данных. Не удалось найти начальный блок ");

            _blockchain = new List<Block>();
            _blockchain.Add(new Block(blockFirst));

            for (int i = 1; i < blocks.Count; i++)
            {
                _blockchain.Add(new Block(blocks[i]));
            }
            
        }

        public Blockchain()
        {
            _blockchain = new List<Block>();
            _blockchain.Add(new Block());
        }

        public void PushBlock(Block block)
        {
            if (BlockLast == null)            
                throw new ArgumentNullException("Цепочка данных не объявлена");            

            if (!BlockLast.Hash.Equals(block.PrevHash))            
                throw new ArgumentException($"Нарушение целостности данных. Хэш предыдущего блока не соответствует хэшу в добавляемом блоке.") ;
                
            block.Number = BlockLast.Number + 1;
            _blockchain.Add(block);           
        }

        public void PushBlock(BlockDto blockDto)
        {
            var block = new Block(blockDto);
            PushBlock(block);            
        }

        public IEnumerator<Block> GetEnumerator()
        {
            return _blockchain.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _blockchain.GetEnumerator();
        }
    }
}
