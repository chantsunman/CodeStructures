﻿using CodeStructures.Design.Common.Reports.Interfaces;
using CodeStructures.Design.Steel.GB.Interfaces;
using System;

namespace CodeStructures.Design.Steel.GB.Compression.BaseClasses.FlexuralBucking
{
    public abstract class ColumnFlexuralBuckling : SteelColumn
    {

        public ColumnFlexuralBuckling(ISteelSection Section, double L_ex, double L_ey, ICalcLog CalcLog)
            : base(Section, L_ex, L_ey, CalcLog)
        {

        }

        public double GetFlexuralElasticBucklingStressFe()
        {

            double FeMinor = GetFeSingleAxis(false);
            double FeMajor = GetFeSingleAxis(true);

            return Math.Min(FeMinor, FeMajor);
        }

        protected virtual double GetSlendernessKLr(bool IsMajorAxis)
        {
            double K;
            double L;
            double r;
            if (IsMajorAxis == true)
            {
                L = L_ex;
                r = Section.Shape.r_x;

            }
            else
            {
                L = L_ey;
                r = Section.Shape.r_y;

            }

            double Slenderness = L / r;
            return Slenderness;
        }

        private double GetFeSingleAxis(bool IsMajorAxis)
        {
            double E = Section.Material.ModulusOfElasticity;

            double Slenderness = GetSlendernessKLr(IsMajorAxis);

            double Fe;

            if (Slenderness == 0)
            {
                //double F_y = this.Section.Material.YieldStress;
                //Fe = F_y;
                Fe = double.PositiveInfinity;
            }
            else
            {
                Fe = GetF_e(E, Slenderness);
            }

            return Fe;

        }

        protected virtual double GetF_e(double E, double SlendernessKLr)
        {
            double Fe = 0;
            double Slenderness = SlendernessKLr;

            FlexuralBucklingCriticalStressCalculator fcalc = new FlexuralBucklingCriticalStressCalculator();

            Fe = fcalc.GetF_e(E, Slenderness);
            //if (Slenderness != 0)
            //{
            //    //(E3-4)
            //    Fe = Math.Pow(Math.PI, 2) * E / Math.Pow(Slenderness, 2);
            //}
            //else
            //{
            //    return double.PositiveInfinity;
            //}

            return Fe;

        }


        protected virtual double GetCriticalStressFcr(double Fe, double Q = 1.0)
        {


            double Fcr = 0.0;
            double Fy = Section.Material.YieldStress;

            FlexuralBucklingCriticalStressCalculator fcalc = new FlexuralBucklingCriticalStressCalculator();
            return fcalc.GetCriticalStressFcr(Fe, Fy, Q);
            //if (Fe != double.PositiveInfinity)
            //{
            //    double stressRatio = Q * Fy / Fe;

            //    if (stressRatio > 2.25)
            //    {
            //        Fcr = 0.877 * Fe; // (E3-3) if Q<1 then (E7-3)
            //    }
            //    else
            //    {
            //        Fcr = Q * Math.Pow(0.658, stressRatio) * Fy; //(E3-2)  if Q<1 then (E7-2)
            //    }  
            //}
            //else
            //{
            //    Fcr = Fy;
            //}




            //return Fcr;
        }

        public double GetCriticalStressFcr_Y()
        {
            double Fcr = GetFeSingleAxis(false);
            return Fcr;
        }

        public double GetCriticalStressFcr_X()
        {
            double Fcr = GetFeSingleAxis(true);
            return Fcr;
        }

        public double GetReductionFactorQ(double Fcr)
        {
            double Qs = GetReductionFactorForUnstiffenedElementQs();
            double Qa = GetReductionFactorForStiffenedElementQa(Fcr);


            double Q = Qs * Qa; //User Note for E7
            return Q;
        }

        public virtual double GetReductionFactorForStiffenedElementQa(double Fcr)
        {
            return 1.0;
        }

        public virtual double GetReductionFactorForUnstiffenedElementQs()
        {
            return 1.0;
        }

    }

}