using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    internal class Player
    {
        public int HandCount
        {
            get { return m_Hand.Count(); }
        }

        private Cards m_Hand = new Cards(Enumerable.Empty<Card>());

        public void GivePlayerCards(Cards cards)
        {
            m_Hand = cards;
        }

        public Card PopCard()
        {
            return m_Hand.Pop();
        }
    }
}