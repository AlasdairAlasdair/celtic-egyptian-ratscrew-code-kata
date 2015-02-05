using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    internal class Game
    {
        private readonly Cards m_Deck;
        private readonly List<Player> m_Players;

        public Game(IEnumerable<Player> players, Cards deck)
        {
            m_Deck = deck;
            m_Players = players.ToList();
        }

        public void Begin()
        {
            var dealer = new Dealer();

            List<Cards> dealtHands = dealer.Deal(m_Players.Count, m_Deck);

            for (int i = 0; i < m_Players.Count; i++)
            {
                m_Players[i].GivePlayerCards(dealtHands[i]);
            }
        }
    }
}