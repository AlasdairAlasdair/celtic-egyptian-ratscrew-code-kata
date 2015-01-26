using System.Linq;

namespace CelticEgyptianRatscrewKata.SnapValidation
{
    internal class DarkQueenSnapValidator : ISnapValidator
    {
        private static readonly Card s_DarkQueenCard = new Card(Suit.Spades, Rank.Queen);

        public bool DoesStackContainSnap(Stack stack)
        {
            var topCard = stack.FirstOrDefault();
            return topCard != null && topCard.Equals(s_DarkQueenCard);
        }
    }
}