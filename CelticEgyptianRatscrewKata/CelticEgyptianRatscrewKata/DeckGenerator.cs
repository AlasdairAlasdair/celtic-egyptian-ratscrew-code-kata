using System;
using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    internal static class DeckGenerator
    {
        public static Cards GetStandardDeck()
        {
            var everyCard = GetEveryCard();
            return new Cards(everyCard);
        }

        private static IEnumerable<Card> GetEveryCard()
        {
            return from Suit suit in Enum.GetValues(typeof(Suit)) 
                from Rank rank in Enum.GetValues(typeof(Rank)) 
                select new Card(suit, rank);
        }
    }
}