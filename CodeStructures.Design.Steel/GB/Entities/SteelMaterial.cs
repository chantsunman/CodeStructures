using CodeStructures.Design.Steel.GB.Interfaces;

namespace CodeStructures.Design.Steel.GB.Entities
{
    public class SteelMaterial : ISteelMaterial
    {

        public double YieldStress { get; set; }
        public double UltimateStress { get; set; }

        public double ModulusOfElasticity { get; set; }
        public double ShearModulus { get; set; }

        public SteelMaterial(double YieldStress, double UltimateStress, double ModulusOfElasticity, double ShearModulus)
        {
            this.YieldStress = YieldStress;
            this.UltimateStress = UltimateStress;
            this.ModulusOfElasticity = ModulusOfElasticity;
            this.ShearModulus = ShearModulus;
        }

        public SteelMaterial(double YieldStress)
        {
            this.YieldStress = YieldStress;
            this.UltimateStress = double.PositiveInfinity;
        }

        public SteelMaterial(double YieldStress, double ModulusOfElasticity)
        {
            this.YieldStress = YieldStress;
            this.ModulusOfElasticity = ModulusOfElasticity;
            this.ShearModulus = 11200.0;
            this.UltimateStress = YieldStress * 1.3;
        }
    }

}
