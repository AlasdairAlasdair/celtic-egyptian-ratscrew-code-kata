using System.Linq;

namespace CelticEgyptianRatscrewKata.SnapValidation
{
    internal class StandardSnapValidator : ISnapValidator
    {
        public bool DoesStackContainSnap(Stack stack)
        {
            var cardsinalist = stack.ToList();
            for (int i = 0; i < cardsinalist.Count - 1; i++)
            {
                if (cardsinalist[i].Rank == cardsinalist[i + 1].Rank)
                {
                    return true;
                }
            }
            return false;
            //return stack.Zip(stack.Skip(1), (prev, cur) => prev.Rank == cur.Rank).Any(x => x);
            //var doesStackContainSnap = stack.Reverse().ToList();
            //return doesStackContainSnap.Count >= 2 && doesStackContainSnap[0].Rank == doesStackContainSnap[1].Rank;
        }
    }
}
