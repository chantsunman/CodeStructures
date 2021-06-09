using CodeStructures.Design.Common.Section.Interfaces;
using CodeStructures.Design.Steel.GB.Interfaces;

namespace CodeStructures.Design.Steel.GB.Entities.Sections
{
    public class SteelSectionI : SteelSectionBase
    {
        private ISectionI section;

        public ISectionI Section
        {
            get { return section; }
        }

        public override ISection Shape
        {
            get { return section as ISection; }
        }

        public SteelSectionI(ISectionI Section, ISteelMaterial Material)
            : base(Material)
        {
            this.section = Section;
        }


    }

}
