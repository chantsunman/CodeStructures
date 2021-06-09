using CodeStructures.Design.Common.Entities;
using CodeStructures.Design.Common.Section.Interfaces;
using CodeStructures.Design.Common.Section.SectionTypes.Predefined;
using CodeStructures.Design.Steel.GB.Compression.I;
using CodeStructures.Design.Steel.GB.Entities;
using CodeStructures.Design.Steel.GB.Entities.Sections;
using CodeStructures.Design.Steel.GB.Interfaces;
using Xunit;

namespace CodeStructures.Design.Streel.Tests.GB50017.DesignExamples
{

    public class CompressionMembersTests
    {
        [Fact]
        public void E1AReturnsAxialCapacity()
        {
            GbShapeFactory GbShapeFactory = new GbShapeFactory();
            ISectionI section = (ISectionI)GbShapeFactory.GetShape("W14X90", ShapeTypeSteel.IShapeRolled);
            ISteelMaterial Material = new SteelMaterial(65, 29000);
            ISteelSection steelSection = new SteelSectionI(section, Material);
            IShapeCompact col = new IShapeCompact(steelSection, true, 19 * 12, 19 * 12, 19 * 12);
            double phiPn = col.GetFlexuralBucklingStrength().Value;
            Assert.True(phiPn == 903);
        }
    }
}
