namespace CodeStructures.Design.Common.Section.Interfaces
{
    public interface ISectionPipe : ISection, ISectionHollow, IWeakAxisCloneable
    {
        double D { get; }
        double t { get; }
    }
}
