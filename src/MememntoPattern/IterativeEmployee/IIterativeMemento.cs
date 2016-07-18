namespace MememntoPattern.IterativeEmployee
{
    public interface IIterativeMemento<TMemento, TDiff>
    {
        TMemento Clone();
        TDiff GetDiffFor(TMemento e);
        void UpdateWithDelta(TDiff diff);
    }
}