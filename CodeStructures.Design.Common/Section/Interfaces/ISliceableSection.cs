using CodeStructures.Design.Common.Entities;

namespace CodeStructures.Design.Common.Section.Interfaces
{
    public interface ISliceableSection : IMoveableSection, ISection
    {
        IMoveableSection GetTopSliceSection(double PlaneOffset, SlicingPlaneOffsetType OffsetType);
        IMoveableSection GetBottomSliceSection(double PlaneOffset, SlicingPlaneOffsetType OffsetType);
        IMoveableSection GetTopSliceOfArea(double Area);
        IMoveableSection GetBottomSliceOfArea(double Area);

    }
}
