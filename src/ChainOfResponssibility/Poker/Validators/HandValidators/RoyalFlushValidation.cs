using System.Linq;

namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class RoyalFlushValidation : HandValidation
    {
        protected override string IsValid(Card[] hand)
        {
            var gr = hand.GroupBy(x => x.Suite);
            var flush = gr.FirstOrDefault(x => x.Count() == 5);
            if (flush != null)
            {
                var Value2Index = hand.Select((i, j) => i.GetIntValue() - j).Distinct();
                if (!Value2Index.Skip(1).Any() && Value2Index.First() == 10)// consecutive and 10, meaning 10, J, Q, K, A
                    return "You have a Royal Flush with " + string.Join(", ", hand.Select(x => x.ToString()));

                return string.Empty;
            }

            return string.Empty;
        }
    }
}
