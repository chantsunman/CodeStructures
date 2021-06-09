using CodeStructures.Design.Common.Section.Interfaces;

namespace CodeStructures.Design.Common.Section.SectionTypes.Predefined
{
    /// <summary>
    /// Predefined sections are used in case when 
    /// section properties are known: for example in cases of
    /// catalog sections or when section properties are provided by user.
    /// </summary>
    public abstract class SectionPredefinedBase : SectionBase
    {

        //public abstract override ISection Clone();

        public SectionPredefinedBase()
        {

        }
        public SectionPredefinedBase(ISection sec)
        {
            this.A = sec.A;
            this._I_x = sec.I_x;
            this._I_y = sec.I_y;
            this._S_x_Top = sec.S_xTop;
            this._S_xBot = sec.S_xBot;
            this._S_yLeft = sec.S_yLeft;
            this._S_yRight = sec.S_yRight;
            this._Z_x = sec.Z_x;
            this._Z_y = sec.Z_y;
            this._r_x = sec.r_x;
            this._r_y = sec.r_y;
            this.elasticCentroidCoordinate.X = sec.x_Bar;
            this.elasticCentroidCoordinate.Y = sec.y_Bar;
            this.plasticCentroidCoordinate.X = sec.x_pBar;
            this.plasticCentroidCoordinate.Y = sec.y_pBar;
            this._C_w = sec.C_w;
            this._J = sec.J;
        }
    }

}
