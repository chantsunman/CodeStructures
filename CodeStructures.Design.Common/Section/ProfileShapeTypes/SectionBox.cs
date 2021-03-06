using CodeStructures.Design.Common.Mathematics;
using CodeStructures.Design.Common.Section.Interfaces;
using CodeStructures.Design.Common.Section.ProfileShapeTypes.Compound;
using System;
using System.Collections.Generic;

namespace CodeStructures.Design.Common.Section.ProfileShapeTypes
{
    /// <summary>
    /// Generic box shape with geometric parameters provided in a constructor.
    /// It is assumed that the corners are sharp, as is the case in built-up 
    /// box girders and columns.
    /// </summary>
    public class SectionBox : CompoundShape, ISectionBox
    {

        #region Section properties specific to Box
        private double h;

        public double H
        {
            get { return h; }
        }


        private double h_o;

        public double FlangeCentroidDistance
        {
            get { return h_o; }
        }

        private double b;

        public double B
        {
            get { return b; }
        }

        protected double _t_f;

        public double t_f
        {
            get { return _t_f; }
        }

        protected double _t_w;

        public double t_w
        {
            get { return _t_w; }
        }

        private double _h_web;

        public double h_web
        {
            get { return _h_web; }
        }



        public double CornerRadiusOutside
        {
            get { return 0; }
            set { }
        }

        private double _t_des;

        public double t_des
        {
            get
            {
                _t_des = Math.Min(t_f, t_w);
                return _t_des;
            }
            set { _t_des = value; }
        }



        #endregion


        public SectionBox(string Name, double H, double B, double t_f, double t_w) : base(Name)
        {
            this.h = H;
            this.b = B;
            this._t_f = t_f;
            this._t_w = t_w;
            this.h_o = H - _t_f;
            this._h_web = H - 2.0 * _t_f;
        }


        /// <summary>
        /// Defines a set of rectangles for analysis with respect to 
        /// x-axis, each occupying full width of section.
        /// </summary>
        /// <returns>List of analysis rectangles</returns>
        public override List<CompoundShapePart> GetCompoundRectangleXAxisList()
        {
            List<CompoundShapePart> rectX = new List<CompoundShapePart>()
            {
                new CompoundShapePart(B,t_f, new Point2D(0,H/2-t_f/2.0)),
                new CompoundShapePart(t_w*2,H-2*t_f, new Point2D(0,0)),
                new CompoundShapePart(B,t_f, new Point2D(0,-(H/2-t_f/2.0)))
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
            List<CompoundShapePart> rectY = new List<CompoundShapePart>()
            {
                new CompoundShapePart(H,t_w, new Point2D(0,B-t_w/2.0)),
                new CompoundShapePart(2*t_f, B-2*t_w, new Point2D(0,0)),
                new CompoundShapePart(H, t_w, new Point2D(0, -(B-t_w/2.0))),

            };
            return rectY;
        }


        public ISection GetWeakAxisClone()
        {
            string cloneName = this.Name + "_clone";
            return new SectionBox(cloneName, b, h, _t_w, _t_f);
        }


        protected override void CalculateWarpingConstant()
        {
            _C_w = 0.0;
        }

        /// <summary>
        /// From:
        /// TORSIONAL SECTION PROPERTIES OF STEEL SHAPES
        ///Canadian Institute of Steel Construction, 2002
        /// </summary>
        protected override void CalculateTorsionalConstant()
        {
            double p = 2 * ((h - _t_f) + (b - t_w));
            double A_p = (h - _t_f) * (b - t_w);
            _J = ((4 * A_p * A_p * t_w) / (p)); //need to confirm tw in this equation
        }
    }

}
