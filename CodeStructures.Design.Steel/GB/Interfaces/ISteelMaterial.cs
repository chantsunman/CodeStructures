namespace CodeStructures.Design.Steel.GB.Interfaces
{
    public interface ISteelMaterial
    {
        double YieldStress { get; }
        double UltimateStress { get; }
        double ModulusOfElasticity { get; }
        double ShearModulus { get; }
    }
}
