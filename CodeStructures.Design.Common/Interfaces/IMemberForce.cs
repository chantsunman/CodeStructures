namespace CodeStructures.Design.Common.Interfaces
{
    public interface IMemberForce
    {
        double Fx { get; set; }
        double Fy { get; set; }
        double Fz { get; set; }

        double Mx { get; set; }
        double My { get; set; }
        double Mz { get; set; }

        double MemberStation { get; set; }

        string LoadCaseName { get; set; }
    }

}
