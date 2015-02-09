using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    internal class Game
    {
        private readonly Cards m_Deck;
        private readonly IShuffler m_Shuffler;
        private readonly List<Player> m_Players;

        public Game(IEnumerable<Player> players, Cards deck, IShuffler shuffler)
        {
            m_Deck = deck;
            m_Shuffler = shuffler;
            m_Players = players.ToList();
        }

        public void Begin()
        {
            var shufflerDeck = m_Shuffler.Shuffle(m_Deck);

            var dealer = new Dealer();
            var dealtHands = dealer.Deal(m_Players.Count, shufflerDeck);

            for (int i = 0; i < m_Players.Count; i++)
            {
                m_Players[i].GivePlayerCards(dealtHands[i]);
            }
        }
    }
}