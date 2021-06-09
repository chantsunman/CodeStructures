using CodeStructures.Design.Common.Reports.Interfaces;
using CodeStructures.Design.Steel.GB.Entities.Members;
using CodeStructures.Design.Steel.GB.Interfaces;

namespace CodeStructures.Design.Steel.GB.Compression.BaseClasses
{
    public abstract class SteelColumn : SteelAxialMember
    {

        //    public SteelColumn(ISteelSection Section, double L_x, double L_y, double K_x, double K_y, ICalcLog CalcLog)
        //: base(Section, L_x, L_y,K_x,K_y, CalcLog)

        public SteelColumn(ISteelSection Section, double L_ex, double L_ey, ICalcLog CalcLog)
            : base(Section, L_ex, L_ey, CalcLog)
        {

        }


        protected double GetNominalAxialCapacity(double CriticalStress)
        {
            double A = Section.Shape.A;
            return CriticalStress * A;
        }

        protected double GetDesignAxialStrength(double CriticalStress)
        {
            double Pn = GetNominalAxialCapacity(CriticalStress);
            double phiP_n = Pn * 0.90; //per section E1 of specification
            return phiP_n;
        }
        public override double CalculateDesignStrength(bool EccentricBrace)
        {
            double phiP_n = 0.0;
            double Fcr = CalculateCriticalStress(EccentricBrace);
            phiP_n = GetDesignAxialStrength(Fcr);
            return phiP_n;
        }
    }

}
