using CodeStructures.Design.CodeStructures.Design.Common.Section.ProfileShapeTypes.Compound;
using CodeStructures.Design.Common.Mathematics;
using CodeStructures.Design.Common.Section.Interfaces;
using CodeStructures.Design.Common.Section.ProfileShapeTypes.Compound;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeStructures.Design.Common.Section.ProfileShapeTypes.Angle
{
    /// <summary>
    /// Generic double angle shape with geometric parameters provided in a constructor.
    /// </summary>
    public class SectionDoubleAngle : CompoundShape, ISectionDoubleAngle
    {
        public SectionDoubleAngle(string Name, SectionAngle Angle, double Gap)
            : base(Name)
        {
            this.gap = Gap;
            this.angle = Angle;
        }

        private double gap;

        public double Gap
        {
            get { return gap; }
        }

        private SectionAngle angle;

        public ISectionAngle Angle
        {
            get { return angle; }
        }

        /// <summary>
        /// Defines a set of rectangles for analysis with respect to 
        /// x-axis, each occupying full width of section.
        /// </summary>
        /// <returns>List of analysis rectangles</returns>
        public override List<CompoundShapePart> GetCompoundRectangleXAxisList()
        {
            ISectionAngle a = angle;
            List<CompoundShapePart> rectX = new List<CompoundShapePart>()
            {
                new CompoundShapePart(2*a.t,a.d-a.t, new Point2D(a.t/2.0,(a.d-a.t)/2.0)),
                new CompoundShapePart(2*a.b,a.t, new Point2D(a.b/2,a.t/2.0)),
            };
            return rectX;
        }

        /// <summary>
        /// Defines a set of rectangles for analysis with respect to 
        /// y-axis, each occupying full height of section. The rectangles are rotated 90 deg., 
        /// because internally the properties are calculated  with respect to x-axis.
        /// </summary>
        /// <returns>List of analysis rectangles</returns>
        public override List<CompoundShapePart> GetCompoundRectangleYAxisList()
        {
            ISectionAngle a = angle;
            List<CompoundShapePart> rectY = new List<CompoundShapePart>()
            {
                new CompoundShapePart(a.t, a.b-a.t, new Point2D(0,(a.b-a.t)/2 +gap/2.0)),
                new CompoundShapePart(a.d,a.t, new Point2D(0,a.t/2.0+gap/2.0)),
                new CompoundShapePart(a.d,a.t, new Point2D(0,-(a.t/2.0+gap/2.0))),
                new CompoundShapePart(a.t, a.b-a.t,new Point2D(0, -(a.b-a.t)/2.0+gap/2.0)),
            };
            return rectY;
        }



        /// <summary>
        /// From:
        /// TORSIONAL SECTION PROPERTIES OF STEEL SHAPES
        ///Canadian Institute of Steel Construction, 2002
        /// </summary>
        protected override void CalculateWarpingConstant()
        {
            this._C_w = 2 * C_w;
        }
        /// <summary>
        /// From:
        /// TORSIONAL SECTION PROPERTIES OF STEEL SHAPES
        ///Canadian Institute of Steel Construction, 2002
        /// </summary>
        protected override void CalculateTorsionalConstant()
        {
            this._J = 2 * J;
        }
    }

}
