namespace CodeStructures.Design.Common.Section.Interfaces
{
    public interface ISectionTube : ISection, ISectionHollow, IWeakAxisCloneable
    {
        double B { get; }
        double H { get; }
        double CornerRadiusOutside { get; set; }
    }
}
