using System;

namespace CodeStructures.Design.Steel.GB.Compression.BaseClasses.FlexuralBucking
{
    public class FlexuralBucklingCriticalStressCalculator
    {
        public virtual double GetF_e(double E, double Slenderness)
        {
            double Fe = 0;

            if (Slenderness != 0)
            {
                //(E3-4)
                Fe = Math.Pow(Math.PI, 2) * E / Math.Pow(Slenderness, 2);
            }
            else
            {
                return double.PositiveInfinity;
            }

            return Fe;

        }


        public double GetCriticalStressFcr(double Fe, double Fy, double Q = 1.0)
        {


            double Fcr = 0.0;



            if (Fe != double.PositiveInfinity)
            {
                double stressRatio = Q * Fy / Fe;

                if (stressRatio > 2.25)
                {
                    Fcr = 0.877 * Fe; // (E3-3) if Q<1 then (E7-3)
                }
                else
                {
                    Fcr = Q * Math.Pow(0.658, stressRatio) * Fy; //(E3-2)  if Q<1 then (E7-2)
                }
            }
            else
            {
                Fcr = Fy;
            }




            return Fcr;
        }
    }

}
