using CodeStructures.Design.Common.Section.Interfaces;
using CodeStructures.Design.Steel.GB.Compression.BaseClasses.TorsionalBuckling;
using CodeStructures.Design.Steel.GB.Entities;
using CodeStructures.Design.Steel.GB.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeStructures.Design.Steel.GB.Compression.I
{
    public partial class IShapeCompact : ColumnDoublySymmetric
    {
        public bool IsRolled { get; set; }




        public override double CalculateCriticalStress(bool EccentricBrace)
        {
            double Fcr = 0.0;

            //Flexural

            double FeFlexuralBuckling = GetFlexuralElasticBucklingStressFe(); //this does not apply to unsymmetric sections
            double FcrFlexuralBuckling = GetCriticalStressFcr(FeFlexuralBuckling, 1.0);
            double Qflex = GetReductionFactorQ(FcrFlexuralBuckling);
            double FcrFlex = GetCriticalStressFcr(FeFlexuralBuckling, Qflex);

            double FeTorsionalBuckling = GetTorsionalElasticBucklingStressFe(EccentricBrace);
            double FcrTorsionalBuckling = GetCriticalStressFcr(FeTorsionalBuckling, 1.0);
            double Qtors = GetReductionFactorQ(FcrTorsionalBuckling);
            double FcrTors = GetCriticalStressFcr(FeTorsionalBuckling, Qtors);


            Fcr = Math.Min(FcrFlex, FcrTors);
            return Fcr;

        }

        public IShapeCompact(ISteelSection Section, bool IsRolled, double L_x, double L_y, double L_z)
            : base(Section, L_x, L_y, L_z)
        {

            bool IsValidShape = CheckValidShape(Section.Shape);
            if (IsValidShape == true)
            {
                SetShape(Section.Shape);
            }
            else
            {
                throw new Exception("Section of wrong type: Need ISectionI");
            }

            this.IsRolled = IsRolled;
        }

        protected virtual bool CheckValidShape(ISection Shape)
        {
            if (Shape is ISectionI)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual void SetShape(ISection Shape)
        {
            SectionI = Shape as ISectionI;
        }

        protected ISectionI SectionI;

        public override SteelLimitStateValue GetFlexuralBucklingStrength()
        {

            double FeFlexuralBuckling = GetFlexuralElasticBucklingStressFe(); //this does not apply to unsymmetric sections
            double FcrFlexuralBuckling = GetCriticalStressFcr(FeFlexuralBuckling, 1.0);
            double Qflex = GetReductionFactorQ(FcrFlexuralBuckling);
            double FcrFlex = GetCriticalStressFcr(FeFlexuralBuckling, Qflex);

            double phiP_n = GetDesignAxialStrength(FcrFlex);

            SteelLimitStateValue ls = new SteelLimitStateValue(phiP_n, true);
            return ls;
        }

        public override SteelLimitStateValue GetTorsionalAndFlexuralTorsionalBucklingStrength(bool EccentricBrace)
        {
            SteelLimitStateValue ls = new SteelLimitStateValue();
            bool TorsionalBucklingApplicable = CheckIfTorsionalBucklingApplicable(L_ex, L_ey, L_ez);
            if (TorsionalBucklingApplicable == false)
            {
                ls.Value = -1;
                ls.IsApplicable = false;
            }
            else
            {
                double FeTorsionalBuckling = GetTorsionalElasticBucklingStressFe(EccentricBrace);
                double FcrTorsionalBuckling = GetCriticalStressFcr(FeTorsionalBuckling, 1.0);
                double Qtors = GetReductionFactorQ(FcrTorsionalBuckling);
                double FcrTors = GetCriticalStressFcr(FeTorsionalBuckling, Qtors);

                double phiP_n = GetDesignAxialStrength(FcrTors);
                ls.Value = phiP_n;
                ls.IsApplicable = true;

            }
            return ls;

        }

        protected virtual bool CheckIfTorsionalBucklingApplicable(double L_ex, double L_ey, double L_ez)
        {
            if (this.L_ez <= L_ex && this.L_ez <= L_ey)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
