using System;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    internal class GameBuilder
    {
        private const int c_MinNumberOfPlayers = 2;

        private readonly List<Player> m_Players = new List<Player>();

        private Cards m_Deck;
        private IShuffler m_Shuffler;

        public void AddPlayer(Player player)
        {
            m_Players.Add(player);
        }

        public void SetDeck(Cards deck)
        {
            if (m_Deck != null)
            {
                throw new InvalidOperationException("Deck has already been set.");
            }

            m_Deck = new Cards(deck);
        }

        public void SetShuffler(IShuffler shuffler)
        {
            if (m_Shuffler != null)
            {
                throw new InvalidOperationException("Shuffler has already been set.");
            }
            m_Shuffler = shuffler;
        }

        public Game Build()
        {
            if (m_Deck == null)
            {
                throw new InvalidOperationException("There's no deck set for this game.");
            }

            if (m_Shuffler == null)
            {
                throw new InvalidOperationException("There's no shuffler set for this game.");
            }

            if (m_Players.Count > m_Deck.Count())
            {
                throw new InvalidOperationException(string.Format("There are {0} players but only {1} cards in the deck ", m_Players.Count, m_Deck.Count()));
            }

            if (m_Players.Count < c_MinNumberOfPlayers)
            {
                throw new InvalidOperationException(string.Format("There must be at least {0} players", c_MinNumberOfPlayers));
            }

            return new Game(m_Players, m_Deck, m_Shuffler);
        }
    }
}