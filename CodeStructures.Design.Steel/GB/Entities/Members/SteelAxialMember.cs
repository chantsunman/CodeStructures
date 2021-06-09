using CodeStructures.Design.Common.Reports.Interfaces;
using CodeStructures.Design.Steel.GB.Interfaces;

namespace CodeStructures.Design.Steel.GB.Entities.Members
{
    public abstract class SteelAxialMember : SteelMemberBase, ISteelCompressionMember, ISteelTensionMember
    {
        public abstract SteelLimitStateValue GetFlexuralBucklingStrength();
        public abstract SteelLimitStateValue GetTorsionalAndFlexuralTorsionalBucklingStrength(bool EccentricBrace);

        public double L_ex { get; set; }
        public double L_ey { get; set; }
        public double L_ez { get; set; }

        public double CmFactorX { get; set; }
        public double CmFactorY { get; set; }

        private double netArea;

        public double NetArea
        {
            get { return netArea; }
            set { netArea = value; }
        }

        //    public SteelAxialMember(ISteelSection Section, double L_x, double L_y, double K_x, double K_y, ICalcLog CalcLog) //, ISteelMaterial Material)
        //:base(Section,  CalcLog) //,Material)
        public SteelAxialMember(ISteelSection Section, double L_ex, double L_ey, ICalcLog CalcLog) //, ISteelMaterial Material)
            : base(Section, CalcLog) //,Material)
        {
            this.L_ex = L_ex;
            this.L_ey = L_ey;
        }

        public abstract double CalculateDesignStrength(bool EccentricBrace);

        public abstract double CalculateCriticalStress(bool EccentricBrace);


    }

}
