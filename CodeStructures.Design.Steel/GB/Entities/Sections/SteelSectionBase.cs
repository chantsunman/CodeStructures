using CodeStructures.Design.Common.Section.Interfaces;
using CodeStructures.Design.Steel.GB.Interfaces;

namespace CodeStructures.Design.Steel.GB.Entities.Sections
{
    public abstract class SteelSectionBase : ISteelSection
    {
        private ISteelMaterial material;

        public ISteelMaterial Material
        {
            get { return material; }

        }

        public abstract ISection Shape { get; }

        public SteelSectionBase(ISteelMaterial Material)
        {

            this.material = Material;
        }

        //public abstract ISection Clone();
    }

}
