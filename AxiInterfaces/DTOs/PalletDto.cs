using AxiLogic.Classes;

namespace AxiInterfaces.DTOs
{
    public class PalletDto
    {
        public int Amount { get; private set; }
        
        public ArticleDto Article { get; private set; }
    }
}