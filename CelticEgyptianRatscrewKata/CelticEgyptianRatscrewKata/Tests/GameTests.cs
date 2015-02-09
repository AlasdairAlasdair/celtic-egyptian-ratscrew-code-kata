using System.Collections.Generic;
using System.Linq;
using Moq;
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
        public void PlayerIsAssignedCardsByGame()
        {
            var stack = new Cards(new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Three),
            });

            var game = new Game(m_TwoPlayers, stack, new Shuffler());
            game.Prepare();

            Assert.That(m_PlayerA.HandCount, Is.GreaterThan(0));
        }

        [Test]
        public void PlayersAreAssignedCardsFairlyByGame()
        {
            var stack = new Cards(new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
            });

            var game = new Game(m_TwoPlayers, stack, new Shuffler());
            game.Prepare();

            Assert.That(m_PlayerA.HandCount, Is.EqualTo(m_PlayerB.HandCount));
        }

        [Test]
        public void ShufflerIsCalled()
        {
            var inputStack = new Cards(new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
            });

            var mockShuffler = new Mock<IShuffler>();
            mockShuffler.Setup(x => x.Shuffle(inputStack)).Returns(inputStack);

            var game = new Game(m_TwoPlayers, inputStack, mockShuffler.Object);
            game.Prepare();

            mockShuffler.Verify(x => x.Shuffle(inputStack), Times.Once());
        }

        [Test]
        public void ShufflerIsUsedToAssignCards()
        {
            var inputStack = new Cards(new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
            });

            var mockShuffler = new Mock<IShuffler>();
            mockShuffler.Setup(x => x.Shuffle(inputStack)).Returns(new Cards(Enumerable.Empty<Card>()));

            var game = new Game(m_TwoPlayers, inputStack, mockShuffler.Object);
            game.Prepare();

            Assert.That(m_PlayerA.HandCount, Is.EqualTo(0));
            Assert.That(m_PlayerB.HandCount, Is.EqualTo(0));
        }

        [Test]
        public void PlayerLaysOneCardPerTurn()
        {
            const int cardsPlayedPerTurn = 1;
            
            var game = new Game(m_TwoPlayers, DeckGenerator.GetStandardDeck(), new Shuffler());
            game.Prepare();
            
            var startingHandCount = m_PlayerA.HandCount;

            game.TakeTurn(m_PlayerA);

            Assert.That(m_PlayerA.HandCount, Is.EqualTo(startingHandCount - cardsPlayedPerTurn));
        }
    }
}
