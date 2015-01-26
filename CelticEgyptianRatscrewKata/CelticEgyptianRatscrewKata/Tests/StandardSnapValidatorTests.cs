using System.Collections.Generic;
using CelticEgyptianRatscrewKata.SnapValidation;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public class StandardSnapValidatorTests
    {
        public static IEnumerable<TestCaseData> BoringTestsCases
        {
            get
            {
                yield return new TestCaseData(new List<Card>()).Returns(false).SetName("Empty stack");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Spades, Rank.Ace) }).Returns(false).SetName("Stack with 1 card");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Spades, Rank.Ace), new Card(Suit.Clubs, Rank.Two) }).Returns(false).SetName("Two different cards");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Spades, Rank.Ace), new Card(Suit.Clubs, Rank.Ace) }).Returns(true).SetName("Two cards with same rank is whole stack");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Clubs, Rank.Ace), new Card(Suit.Clubs, Rank.Ace) }).Returns(true).SetName("Two identical cards"); // should never throw an exception because might run the product code on multi-decks one day...?
                yield return new TestCaseData(new List<Card> { new Card(Suit.Clubs, Rank.Ace), new Card(Suit.Clubs, Rank.Two) }).Returns(false).SetName("Two cards with same suit");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Hearts, Rank.Two), new Card(Suit.Spades, Rank.Ace), new Card(Suit.Clubs, Rank.Ace) }).Returns(true).SetName("Two cards with same rank at end of stack");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Spades, Rank.Ace), new Card(Suit.Clubs, Rank.Ace), new Card(Suit.Hearts, Rank.Two) }).Returns(true).SetName("Two cards with same rank at start of stack");
            }
        }

        [TestCaseSource("BoringTestsCases")]
        public bool RunBoringTest(IEnumerable<Card> cards)
        {
            return new StandardSnapValidator().DoesStackContainSnap(new Stack(cards));
        }
    }
}
