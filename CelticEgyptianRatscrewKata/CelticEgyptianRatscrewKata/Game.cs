using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    internal class Game
    {
        private readonly Cards m_InitialDeck;
        private readonly IShuffler m_Shuffler;
        private readonly List<Player> m_Players;
        private Cards m_GameDeck;

        public Game(IEnumerable<Player> players, Cards initialDeck, IShuffler shuffler)
        {
            m_InitialDeck = initialDeck;
            m_Shuffler = shuffler;
            m_Players = players.ToList();
        }

        public void Prepare()
        {
            m_GameDeck = m_Shuffler.Shuffle(m_InitialDeck);

            var dealer = new Dealer();
            var dealtHands = dealer.Deal(m_Players.Count, m_GameDeck);

            for (int i = 0; i < m_Players.Count; i++)
            {
                m_Players[i].GivePlayerCards(dealtHands[i]);
            }
        }

        public void TakeTurn(Player player)
        {
            if (player.HandCount > 0)
            {
                var playerTopCard = player.PopCard();
                m_GameDeck.AddToTop(playerTopCard);    
            }
        }
    }
}