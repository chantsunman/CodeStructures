namespace CodeStructures.Design.Common.Section.Interfaces
{
    public interface ISectionDoubleAngle : ISection
    {
        ISectionAngle Angle { get; }
        double Gap { get; }
    }
}
