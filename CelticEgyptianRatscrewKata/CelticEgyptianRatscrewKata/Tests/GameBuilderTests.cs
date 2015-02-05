using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    class GameBuilderTests
    {
        public static List<Card> threeCardsList = new List<Card>
                                {
                                    new Card(Suit.Clubs, Rank.Ace),
                                    new Card(Suit.Clubs, Rank.Two),
                                    new Card(Suit.Clubs, Rank.Three),
                                };
        public static Cards threeCards = new Cards(threeCardsList);

        [Test]
        public void CanBuildValidGame()
        {
            var gameBuilder = new GameBuilder();
            gameBuilder.AddPlayer(new Player());
            gameBuilder.AddPlayer(new Player());

            gameBuilder.SetDeck(new Cards(threeCards));

            Assert.DoesNotThrow(() => gameBuilder.Build());
        }

        [Test]
        public void CannotBuildGameWithEmptyDeck()
        {
            var gameBuilder = new GameBuilder();
            gameBuilder.AddPlayer(new Player());
            gameBuilder.AddPlayer(new Player());

            gameBuilder.SetDeck(new Cards(Enumerable.Empty<Card>()));

            Assert.Throws<InvalidOperationException>(() => gameBuilder.Build());
        }

        [Test]
        public void ValidGameMustHaveAtLeastTwoPlayers()
        {
            var gameBuilder = new GameBuilder();
            gameBuilder.AddPlayer(new Player());

            Assert.Throws<InvalidOperationException>(() => gameBuilder.Build());
        }

        [Test]
        public void ValidGameMustHaveAtLeastOneCardPerPlayer()
        {
            int morePlayersThanCards = threeCards.Count() + 1;

            var gameBuilder = new GameBuilder();
            for (int i = 0; i < morePlayersThanCards; i++)
            {
                gameBuilder.AddPlayer(new Player());
            }

            gameBuilder.SetDeck(threeCards);

            Assert.Throws<InvalidOperationException>(() => gameBuilder.Build());
        }
    }
}
