using System.Linq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    class DeckGeneratorTests
    {
        [Test]
        public void StandardDeckHas52Cards()
        {
            var stdDeck = DeckGenerator.GetStandardDeck();
            Assert.That(stdDeck.Count(), Is.EqualTo(52));
        }
        
        [Test]
        public void AllCardsInStandardDeckAreUnique()
        {
            var stdDeck = DeckGenerator.GetStandardDeck();
            CollectionAssert.AllItemsAreUnique(stdDeck);
        }
    }
}