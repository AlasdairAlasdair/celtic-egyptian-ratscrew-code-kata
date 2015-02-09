using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class FullGameTests
    {
        [Test]
        public void GameIsCreatedWith52Cards()
        {
            var gameBuilder = new GameBuilder();

            var playerA = new Player();
            gameBuilder.AddPlayer(playerA);

            var playerB = new Player();
            gameBuilder.AddPlayer(playerB);

            Cards standardDeck = DeckGenerator.GetStandardDeck();
            gameBuilder.SetDeck(standardDeck);

            gameBuilder.SetShuffler(new Shuffler());

            var build = gameBuilder.Build();
            build.Begin();

            Assert.That(playerA.HandCount, Is.EqualTo(26));
            Assert.That(playerB.HandCount, Is.EqualTo(26));
        }
    }
}
