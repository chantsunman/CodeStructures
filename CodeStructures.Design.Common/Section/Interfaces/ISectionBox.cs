namespace CodeStructures.Design.Common.Section.Interfaces
{
    public interface ISectionBox : ISectionTube, IWeakAxisCloneable
    {
        double H { get; }
        double FlangeCentroidDistance { get; }
        double t_f { get; }
        double h_web { get; }
        double t_w { get; }
        double B { get; }
    }
}
