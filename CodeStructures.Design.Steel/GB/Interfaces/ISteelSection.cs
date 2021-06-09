using CodeStructures.Design.Common.Section.Interfaces;

namespace CodeStructures.Design.Steel.GB.Interfaces
{
    public interface ISteelSection
    {
        ISection Shape { get; }
        ISteelMaterial Material { get; }
    }
}
