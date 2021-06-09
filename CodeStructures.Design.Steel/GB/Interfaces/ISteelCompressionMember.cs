using CodeStructures.Design.Steel.GB.Entities;

namespace CodeStructures.Design.Steel.GB.Interfaces
{
    public interface ISteelCompressionMember : ISteelMember
    {

        double L_ex { get; set; }
        double L_ey { get; set; }
        double L_ez { get; set; }


        SteelLimitStateValue GetFlexuralBucklingStrength();
        SteelLimitStateValue GetTorsionalAndFlexuralTorsionalBucklingStrength(bool EccentricBrace);
    }

}
