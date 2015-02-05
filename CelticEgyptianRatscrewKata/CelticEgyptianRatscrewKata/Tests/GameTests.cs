using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    class GameTests
    {
        private List<Player> m_TwoPlayers;

        private Player m_PlayerA;
        private Player m_PlayerB;

        [SetUp]
        public void Setup()
        {
            m_PlayerA = new Player();
            m_PlayerB = new Player();

            m_TwoPlayers = new List<Player>
            {
                m_PlayerA,
                m_PlayerB,
            };
        }

        [Test]
        public void PlayersAssignedCardsAfterGameBegun()
        {
            var stack = new Cards(new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Three),
            });

            var game = new Game(m_TwoPlayers, stack);
            game.Begin();

            Assert.That(m_PlayerA.HandCount, Is.GreaterThan(0));
            Assert.That(m_PlayerB.HandCount, Is.GreaterThan(0));
        }
    }
}
