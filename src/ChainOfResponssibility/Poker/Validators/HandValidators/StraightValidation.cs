using System.Linq;

namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class StraightValidation : HandValidation
    {
        protected override string IsValid(Card[] hand)
        {
            var Value2Index = hand.Select((i, j) => i.GetIntValue() - j).Distinct();
            if (!Value2Index.Skip(1).Any())// consecutive
                return "You have a Straight with " + string.Join(", ", hand.Select(x => x.ToString()));

            //special case for A,2,3,4,5
            if (Value2Index.Count() == 2
                && Value2Index.First() == 2//for 2,3,4,5
                && Value2Index.Last() == 10)//for A
                return "You have a Straight with " + string.Join(", ", hand.Select(x => x.ToString()));

            return string.Empty;
        }
    }
}
