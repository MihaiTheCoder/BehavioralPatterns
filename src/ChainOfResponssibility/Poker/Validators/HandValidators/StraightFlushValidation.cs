using System.Linq;

namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class StraightFlushValidation : HandValidation
    {
        protected override string IsValid(Card[] hand)
        {
            var gr = hand.GroupBy(x => x.Suite);
            var flush = gr.FirstOrDefault(x => x.Count() == 5);
            if (flush != null)
            {
                var Value2Index = hand.Select((i, j) => i.GetIntValue() - j).Distinct();
                if (!Value2Index.Skip(1).Any())// consecutive
                    return "You have a Straight Flush with " + string.Join(", ", hand.Select(x => x.ToString()));

                //special case for A,2,3,4,5
                if (Value2Index.Count() == 2
                    && Value2Index.First() == 2//for 2,3,4,5
                    && Value2Index.Last() == 10)//for A
                    return "You have a Straight Flush with " + string.Join(", ", hand.Select(x => x.ToString()));

                return string.Empty;
            }

            return string.Empty;
        }
    }
}
