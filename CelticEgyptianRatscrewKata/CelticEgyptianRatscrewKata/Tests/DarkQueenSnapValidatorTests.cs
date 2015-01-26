using System.Collections.Generic;
using CelticEgyptianRatscrewKata.SnapValidation;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public class DarkQueenSnapValidatorTests
    {
        public static IEnumerable<TestCaseData> BoringTestsCases
        {
            get
            {
                yield return new TestCaseData(new List<Card>()).Returns(false).SetName("Empty stack");
                yield return new TestCaseData(new List<Card>{ new Card(Suit.Clubs, Rank.Seven)}).Returns(false).SetName("Stack of one non DQ card by rank and suit");
                yield return new TestCaseData(new List<Card>{ new Card(Suit.Spades, Rank.Queen)}).Returns(true).SetName("Stack of one DQ card");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Spades, Rank.Two) }).Returns(false).SetName("Stack of one non DQ card by suit");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Hearts, Rank.Queen) }).Returns(false).SetName("Stack of one non DQ card by rank");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Spades, Rank.Queen), new Card(Suit.Hearts, Rank.Queen)}).Returns(true).SetName("Stack of two cards DQ at first position");
                yield return new TestCaseData(new List<Card> { new Card(Suit.Hearts, Rank.Queen), new Card(Suit.Spades, Rank.Queen) }).Returns(false).SetName("Stack of two cards DQ at second position");
            }
        }

        [TestCaseSource("BoringTestsCases")]
        public bool RunBoringTest(IEnumerable<Card> cards)
        {
            return new DarkQueenSnapValidator().DoesStackContainSnap(new Stack(cards));
        }
    }
}
