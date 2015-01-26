using System.Collections.Generic;
using CelticEgyptianRatscrewKata.SnapValidation;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public class SandwichSnapValidatorTests
    {
        public static IEnumerable<TestCaseData> BoringTestsCases
        {
            get
            {
                yield return new TestCaseData(new List<Card>()).Returns(false).SetName("Empty stack");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Spades, Rank.Ace) }).Returns(false).SetName("Stack with 1 card");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Spades, Rank.Ace), 
                    new Card(Suit.Spades, Rank.Three) })
                    .Returns(false)
                    .SetName("Stack with 2 card");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Spades, Rank.Ace), 
                    new Card(Suit.Diamonds, Rank.Four), 
                    new Card(Suit.Clubs, Rank.Two) }).Returns(false).SetName("Two different cards");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Spades, Rank.Ace), 
                    new Card(Suit.Diamonds, Rank.Four), 
                    new Card(Suit.Clubs, Rank.Ace) }).Returns(true).SetName("Two cards with same rank is whole stack");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Clubs, Rank.Ace), 
                    new Card(Suit.Diamonds, Rank.Four), 
                    new Card(Suit.Clubs, Rank.Ace) }).Returns(true).SetName("Two identical cards"); // should never throw an exception because might run the product code on multi-decks one day...?
                yield return new TestCaseData(new List<Card> { new Card(Suit.Clubs, Rank.Ace), 
                    new Card(Suit.Diamonds, Rank.Four), new Card(Suit.Clubs, Rank.Two) })
                    .Returns(false)
                    .SetName("Sandwich by suit");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Hearts, Rank.Two), 
                    new Card(Suit.Spades, Rank.Ace), new Card(Suit.Diamonds, Rank.Four), 
                    new Card(Suit.Clubs, Rank.Ace) })
                    .Returns(true)
                    .SetName("Sandwich by rank at end of stack");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Spades, Rank.Ace), 
                    new Card(Suit.Diamonds, Rank.Four),
                    new Card(Suit.Clubs, Rank.Ace), 
                    new Card(Suit.Hearts, Rank.Two) })
                    .Returns(true)
                    .SetName("Sandwich by rank at start of stack");
            }
        }

        [TestCaseSource("BoringTestsCases")]
        public bool RunBoringTest(IEnumerable<Card> cards)
        {
            return new SandwichSnapValidator().DoesStackContainSnap(new Stack(cards));
        }
    }
}
