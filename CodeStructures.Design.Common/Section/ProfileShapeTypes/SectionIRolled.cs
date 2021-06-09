using CodeStructures.Design.Common.Mathematics;
using CodeStructures.Design.Common.Section.Interfaces;
using CodeStructures.Design.Common.Section.ProfileShapeTypes.Compound;
using System.Collections.Generic;

namespace CodeStructures.Design.Common.Section.ProfileShapeTypes
{
    /// <summary>
    /// Generic I-shape with geometric parameters provided in a constructor.
    /// This shapes accounts for fillet areas as is typical for rolled shapes.
    /// </summary>
    public class SectionIRolled : SectionI, ISectionIRolled
    {

        public SectionIRolled(string Name, double d, double b_f, double t_f,
            double t_w, double k)
            : base(Name, d, b_f, t_f, t_w)
        {
            this.k = k;
        }


        private double _T;

        public double T
        {
            get
            {
                _T = d - t_f - t_fBot - 2 * k;
                return _T;
            }
        }

        private double _k;

        public double k
        {
            get { return _k; }
            set { _k = value; }
        }

        double r; //fillet radius

        /// <summary>
        /// Defines a set of rectangles for analysis with respect to 
        /// x-axis, each occupying full width of section.
        /// </summary>
        /// <returns>List of analysis rectangles</returns>
        public override List<CompoundShapePart> GetCompoundRectangleXAxisList()
        {
            double t_f = this.t_f;
            double b_f = this.b_f;
            r = k - t_f;
            CompoundShapePart TopFlange = new CompoundShapePart(b_f, t_f, new Point2D(0, d - t_f / 2.0));
            CompoundShapePart BottomFlange = new CompoundShapePart(b_f, t_f, new Point2D(0, t_f / 2.0));
            CompoundShapePart Web = new CompoundShapePart(t_w, d - 2 * (t_f + r), new Point2D(0, d / 2.0));
            PartWithDoubleFillet TopFillet = new PartWithDoubleFillet(r, t_w, new Point2D(0, d - t_f), true);
            PartWithDoubleFillet BottomFillet = new PartWithDoubleFillet(r, t_w, new Point2D(0, t_f), false);

            List<CompoundShapePart> Ishape = new List<CompoundShapePart>()
            {
                 TopFlange,
                 TopFillet,
                 Web,
                 BottomFillet,
                 BottomFlange
            };
            return Ishape;
        }

        /// <summary>
        /// Defines a set of rectangles for analysis with respect to 
        /// y-axis, each occupying full height of section. The rectangles are rotated 90 deg., 
        /// because internally the properties are calculated  with respect to x-axis.
        /// </summary>
        /// <returns>List of analysis rectangles</returns>
        public override List<CompoundShapePart> GetCompoundRectangleYAxisList()
        {
            double FlangeThickness = this.t_f;
            double FlangeWidth = this.b_f;
            r = k - t_f;
            double FlangeOverhang = (FlangeWidth - t_w - 2.0 * r) / 2.0;

            CompoundShapePart LeftFlange = new CompoundShapePart(2 * FlangeThickness, FlangeOverhang,
                new Point2D(0, b_f - FlangeOverhang / 2.0));

            CompoundShapePart RightFlange = new CompoundShapePart(2 * FlangeThickness, FlangeOverhang,
                new Point2D(0, FlangeOverhang / 2.0));

            PartWithDoubleFillet LeftFillet = new PartWithDoubleFillet(r, 2 * FlangeThickness, new Point2D(0, b_f - FlangeOverhang), false);
            PartWithDoubleFillet RightFillet = new PartWithDoubleFillet(r, 2 * FlangeThickness, new Point2D(0, FlangeOverhang), true);
            CompoundShapePart Web = new CompoundShapePart(d, t_w, new Point2D(0, b_f / 2.0));

            List<CompoundShapePart> rectY = new List<CompoundShapePart>()
            {
                LeftFlange,
                LeftFillet,
                Web,
                RightFillet,
                RightFlange
            };
            return rectY;
        }

    }

}
