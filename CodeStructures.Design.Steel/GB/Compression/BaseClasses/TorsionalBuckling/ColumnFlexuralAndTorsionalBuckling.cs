using CodeStructures.Design.Common.Reports.Interfaces;
using CodeStructures.Design.Steel.GB.Compression.BaseClasses.FlexuralBucking;
using CodeStructures.Design.Steel.GB.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeStructures.Design.Steel.GB.Compression.BaseClasses.TorsionalBuckling
{
    public abstract partial class ColumnFlexuralAndTorsionalBuckling : ColumnFlexuralBuckling
    {


        public ColumnFlexuralAndTorsionalBuckling(ISteelSection Section, double L_ex, double L_ey, double L_ez, ICalcLog CalcLog)
        : base(Section, L_ex, L_ey, CalcLog)
        {
            this.L_ez = L_ez;

        }


        double xo, yo;

        public double GetH()
        {
            double ro2 = Get_roSquare();
            double H = 1.0 - (xo * xo + yo * yo) / ro2; //(E4-10)
            return H;
        }

        public double Get_roSquare()
        {
            double Ix = Section.Shape.I_x;
            double Iy = Section.Shape.I_y;
            double Ag = Section.Shape.A;

            double ro2 = xo * xo + yo * yo + (Ix + Iy) / Ag; //(E4-11)

            return ro2;
        }


        internal double GetFez()
        {
            double pi2 = Math.Pow(Math.PI, 2);
            double E = Section.Material.ModulusOfElasticity;
            double Cw = Section.Shape.C_w;
            double Lz = L_ez;
            double G = 11200; //ksi
            double J = Section.Shape.J;
            double Ag = Section.Shape.A;
            double r0 = Math.Pow(Get_roSquare(), 0.5);


            //(E4-9)
            double Fez = (pi2 * E * Cw / Math.Pow(Lz, 2) + G * J) / (Ag * r0);
            return Fez;
        }

    }

}
