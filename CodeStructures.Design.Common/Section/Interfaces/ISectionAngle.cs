using CodeStructures.Design.Common.Entities;

namespace CodeStructures.Design.Common.Section.Interfaces
{
    public interface ISectionAngle : ISection, IWeakAxisCloneable
    {
        double d { get; }
        double t { get; }
        double b { get; }

        double I_w { get; }
        double I_z { get; }

        double S_w { get; }
        double S_z { get; }

        double r_w { get; }
        double r_z { get; }

        double Angle_alpha { get; }

        double beta_w { get; }

        AngleOrientation AngleOrientation { get; }
        AngleRotation AngleRotation { get; }
    }

}
