using BlockChain.Core.Common;

namespace BlockChain.Web.Services
{
    public interface IBlockChainCacheService
    {
        Blockchain GetBlockChain();
        void SetBlockChain(Blockchain blockchain);
    }
}
