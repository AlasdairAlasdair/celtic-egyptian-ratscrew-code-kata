using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    class GameBuilderTests
    {
        public static List<Card> m_ThreeCardsList = new List<Card>
        {
            new Card(Suit.Clubs, Rank.Ace),
            new Card(Suit.Clubs, Rank.Two),
            new Card(Suit.Clubs, Rank.Three),
        };

        public static Cards m_ThreeCards = new Cards(m_ThreeCardsList);

        [Test]
        public void CanBuildValidGame()
        {
            var gameBuilder = new GameBuilder();
            gameBuilder.AddPlayer(new Player());
            gameBuilder.AddPlayer(new Player());

            gameBuilder.SetDeck(new Cards(m_ThreeCards));

            gameBuilder.SetShuffler(new Shuffler());

            Assert.DoesNotThrow(() => gameBuilder.Build());
        }

        [Test]
        public void CannotBuildGameWithEmptyShuffler()
        {
            var gameBuilder = new GameBuilder();
            gameBuilder.AddPlayer(new Player());
            gameBuilder.AddPlayer(new Player());

            gameBuilder.SetDeck(new Cards(m_ThreeCards));

            Assert.Throws<InvalidOperationException>(() => gameBuilder.Build());
        }

        [Test]
        public void CannotBuildGameWithNoDeckSet()
        {
            var gameBuilder = new GameBuilder();
            gameBuilder.AddPlayer(new Player());
            gameBuilder.AddPlayer(new Player());

            gameBuilder.SetShuffler(new Shuffler());

            Assert.Throws<InvalidOperationException>(() => gameBuilder.Build());
        }

        [Test]
        public void CannotBuildGameWithEmptyDeck()
        {
            var gameBuilder = new GameBuilder();
            gameBuilder.AddPlayer(new Player());
            gameBuilder.AddPlayer(new Player());

            gameBuilder.SetDeck(new Cards(Enumerable.Empty<Card>()));

            gameBuilder.SetShuffler(new Shuffler());

            Assert.Throws<InvalidOperationException>(() => gameBuilder.Build());
        }

        [Test]
        public void ValidGameMustHaveAtLeastTwoPlayers()
        {
            var gameBuilder = new GameBuilder();
            gameBuilder.AddPlayer(new Player());

            gameBuilder.SetDeck(new Cards(m_ThreeCards));

            gameBuilder.SetShuffler(new Shuffler());

            Assert.Throws<InvalidOperationException>(() => gameBuilder.Build());
        }

        [Test]
        public void ValidGameMustHaveAtLeastOneCardPerPlayer()
        {
            int morePlayersThanCards = m_ThreeCards.Count() + 1;

            var gameBuilder = new GameBuilder();
            for (int i = 0; i < morePlayersThanCards; i++)
            {
                gameBuilder.AddPlayer(new Player());
            }

            gameBuilder.SetDeck(m_ThreeCards);

            gameBuilder.SetShuffler(new Shuffler());

            Assert.Throws<InvalidOperationException>(() => gameBuilder.Build());
        }
    }
}
