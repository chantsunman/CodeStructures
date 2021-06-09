using CodeStructures.Design.Common.Mathematics;

namespace CodeStructures.Design.Common.Section.Interfaces
{
    public interface IMoveableSection : IMeasurableAreaSection //: ISection
    {
        Point2D PlasticCentroidCoordinate { get; }
        Point2D GetElasticCentroidCoordinate();
        double YMax { get; }
        double YMin { get; }
        double XMax { get; }
        double XMin { get; }
    }
}
