using CodeStructures.Design.Common.Mathematics;
using CodeStructures.Design.Common.Section.Interfaces;
using CodeStructures.Design.Common.Section.ProfileShapeTypes.Compound;
using System.Collections.Generic;

namespace CodeStructures.Design.Common.Section.ProfileShapeTypes
{
    /// <summary>
    /// Generic channel shape with geometric parameters provided in a constructor.
    /// This shape accounts for rounded fillet corners, but not the sloped flanges
    /// </summary>
    public class SectionChannelRolled : SectionChannel, ISectionChannelRolled
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Name">Shape name</param>
        /// <param name="d">Overall depth of member</param>
        /// <param name="b_f">Flange width</param>
        /// <param name="t_f"> Flange thickness (average)</param>
        /// <param name="t_w">Web thickness</param>
        /// <param name="k">Fillet distance (k)</param>
        public SectionChannelRolled(string Name, double d, double b_f,
            double t_f, double t_w,
            double k)
            : base(Name, d, b_f, t_f, t_w)
        {
            this._k = k;
        }


        private double _T;

        public double T
        {
            get
            {
                _T = d - 2 * t_f;
                return _T;
            }

        }

        private double _k;

        public double k
        {
            get { return _k; }
        }




        /// <summary>
        /// Defines a set of rectangles for analysis with respect to 
        /// x-axis, each occupying full width of section.
        /// </summary>
        /// <returns>List of analysis rectangles</returns>
        public override List<CompoundShapePart> GetCompoundRectangleXAxisList()
        {
            //double FlangeThickness = this.t_fTop;
            //double FlangeWidth = this.b_fTop;

            CompoundShapePart TopFlange = new CompoundShapePart(b_f, t_f, new Point2D(0, d / 2.0 - t_f / 2.0));
            CompoundShapePart BottomFlange = new CompoundShapePart(b_f, t_f, new Point2D(0, -(d / 2.0 - t_f / 2.0)));
            PartWithDoubleFillet TopFillet = new PartWithSingleFillet(k, t_w, new Point2D(0, d / 2.0 - t_f), true);
            PartWithDoubleFillet BottomFillet = new PartWithSingleFillet(k, t_w, new Point2D(0, -(d / 2.0 - t_f)), false);
            CompoundShapePart Web = new CompoundShapePart(t_w, d - 2 * t_f - 2 * k, new Point2D(0, 0));


            List<CompoundShapePart> rectX = new List<CompoundShapePart>()
            {
                 TopFlange,
                 TopFillet,
                 Web,
                 BottomFillet,
                 BottomFlange
            };
            return rectX;
        }

        /// <summary>
        /// Defines a set of rectangles for analysis with respect to 
        /// y-axis, each occupying full d of section. The rectangles are rotated 90 deg., 
        /// because internally the properties are calculated  with respect to x-axis.
        /// </summary>
        /// <returns>List of analysis rtangles</returns>
        public override List<CompoundShapePart> GetCompoundRectangleYAxisList()
        {
            //double t_f = this.t_fTop;
            //double b_f = this.b_fTop;


            //Note: all insertion points are calculated from the left side of the shape
            CompoundShapePart Web = new CompoundShapePart(d, t_w, new Point2D(0, t_w / 2.0));
            PartWithDoubleFillet Fillet = new PartWithDoubleFillet(k, 2 * t_f, new Point2D(0, t_w), true);
            CompoundShapePart Flange = new CompoundShapePart(2 * t_f, b_f - t_w - k,
                new Point2D(0, (t_w + k + (b_f - t_w - k) / 2.0)));


            List<CompoundShapePart> rectY = new List<CompoundShapePart>()
            {
                Web,
                Fillet,
                Flange
            };
            return rectY;
        }


    }

}
